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
		private const string UrlApi = "http://192.168.1.128:5169/api/Author";

		public MainPage()
		{
			InitializeComponent();
			LoadAuthors();
		}

		/// <summary>
		/// Load author to ListView
		/// </summary>
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

		/// <summary>
		/// Button add new author or update author
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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
							string notificationText = "Update author successfully";
							Toast.MakeText(Android.App.Application.Context, notificationText, ToastLength.Long).Show();
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
							string notificationText = "Add new author successfully";
							Toast.MakeText(Android.App.Application.Context, notificationText, ToastLength.Long).Show();
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

		/// <summary>
		/// Button clear text field
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Button_Clicked_1(object sender, EventArgs e)
		{
			IdEntry.Text = null;
			LastNameEntry.Text = null;
			EmailEntry.Text = null;
		}

		/// <summary>
		/// Button delete an author
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void Button_Clicked_2(object sender, EventArgs e)
		{
			string id = IdEntry.Text;
			if(id != null)
			{
				using (HttpClient client = new HttpClient())
				{
					using (HttpResponseMessage res = await client.DeleteAsync(UrlApi + "/" + id))
					{
						if (res.IsSuccessStatusCode)
						{
							string notificationText = "Delete author id: " + id  + " successfully";
							Toast.MakeText(Android.App.Application.Context, notificationText, ToastLength.Long).Show();
							LoadAuthors();
							Button_Clicked_1(sender, e);
						}
						else
						{
							string notificationText = "DELETE request failed";
							Toast.MakeText(Android.App.Application.Context, notificationText, ToastLength.Long).Show();
						};
					}
				}
			}
		}
	}
}
