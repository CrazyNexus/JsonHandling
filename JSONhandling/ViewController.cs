//
// ViewController.cs
//
// Created by Thomas Dubiel on 22.12.2016
// Copyright 2016 Thomas Dubiel. All rights reserved.
//
using System;

using UIKit;
using System.IO;

namespace JSONhandling
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			var movie = new Movie()
			{
				title = "ID4",
				rating = 9,
				releaseDate = DateTime.Now
			};

			string jsonOutput = Newtonsoft.Json.JsonConvert.SerializeObject(movie);
			Console.WriteLine(jsonOutput);

			var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var filename = Path.Combine(documents, "jsonoutput.txt");
			File.WriteAllText(filename, jsonOutput);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		partial void ReadButton_TouchUpInside(UIButton sender)
		{
			var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var filename = Path.Combine(documents, "jsonoutput.txt");
			var storedJson = File.ReadAllText(filename);

			var newMovie = Newtonsoft.Json.JsonConvert.DeserializeObject<Movie>(storedJson);

			Console.WriteLine("Movie Title " + newMovie.title);
		}
	}

	public class Movie
	{
		public string title { get; set; }
		public int rating { get; set; }
		public DateTime releaseDate { get; set; }
	}
}
