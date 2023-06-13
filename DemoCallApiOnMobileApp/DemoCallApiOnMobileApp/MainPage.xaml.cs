using Android.App;
using Android.Provider;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Android.Content.IntentFilter;

namespace DemoCallApiOnMobileApp
{
	public partial class MainPage : ContentPage
	{
		private const string UrlApi = "http://192.168.1.219:5169/api/Author";

		public MainPage()
		{
			InitializeComponent();
			LoadAuthors();
		}
		protected async void LoadAuthors()
		{
			List<Author> authors = new List<Author>();
			using (HttpClient client = new HttpClient())
			{
				using (HttpResponseMessage res = await client.GetAsync(UrlApi))
				{
					using (HttpContent content = res.Content)
					{
						string data = await content.ReadAsStringAsync();
						authors = JsonConvert.DeserializeObject<List<Author>>(data);
					}
				}
			}
			ItemListView.ItemsSource = authors;
		}


		protected async void Button_Clicked(object sender, EventArgs e)
		{
			// Retrieve values from the input fields
			string id = IdEntry.Text;
			string lastName = LastNameEntry.Text;
			string emailAddress = EmailEntry.Text;
			// Create a new Author object with the input values
			Author newAuthor = new Author()
			{
				LastName = lastName,
				EmailAddress = emailAddress
			};
			if (id != null)
			{
				newAuthor.AuthorId = int.Parse(id);
				string data = JsonConvert.SerializeObject(newAuthor);
				using (HttpClient client = new HttpClient())
				{
					using (HttpResponseMessage res = await client.PutAsync(UrlApi + "/" + id, new StringContent(data, Encoding.UTF8, "application/json")))
					{
						if (res.IsSuccessStatusCode)
						{
							LoadAuthors();
							LastNameEntry.Text = "";
							EmailEntry.Text = "";
							IdEntry.Text = null;
						}
						else
						{
							string notificationText = "PUT request failed";
							Toast.MakeText(Android.App.Application.Context, notificationText, ToastLength.Long).Show();
						};
					}
				}
			}
			else
			{
				string data = JsonConvert.SerializeObject(newAuthor);
				using (HttpClient client = new HttpClient())
				{
					using (HttpResponseMessage res = await client.PostAsync(UrlApi, new StringContent(data, Encoding.UTF8, "application/json")))
					{
						if (res.IsSuccessStatusCode)
						{
							LoadAuthors();
							LastNameEntry.Text = "";
							EmailEntry.Text = "";
							IdEntry.Text = null;
						}
						else
						{
							string notificationText = "POST request failed";
							Toast.MakeText(Android.App.Application.Context, notificationText, ToastLength.Long).Show();
						}
					}
				}
			}
		}

		private void ItemListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			// Get the selected author item
			var selectedAuthor = e.SelectedItem as Author;

			// Load the data of the selected author into the input fields for editing
			if (selectedAuthor != null)
			{
				IdEntry.Text = selectedAuthor.AuthorId.ToString();
				LastNameEntry.Text = selectedAuthor.LastName;
				EmailEntry.Text = selectedAuthor.EmailAddress;
			}
		}

		private void Button_Clicked_1(object sender, EventArgs e)
		{
			IdEntry.Text = null;
			LastNameEntry.Text = null;
			EmailEntry.Text = null;
		}
	}
}
