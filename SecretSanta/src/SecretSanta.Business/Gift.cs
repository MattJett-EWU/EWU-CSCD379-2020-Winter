using System;

namespace SecretSanta.Business
{
	public class Gift
	{
		#region Fields
		private string _Title = "";
		private string _Description = "";
		private string _Url = "";
		#endregion


		#region Properties
		public int Id { get; }
		public string Title
		{ 
			get => _Title; 
			set => _Title = AssertIsNotNullOrWhitespace(value); 
		}
		public string Description 
		{ 
			get => _Description; 
			set => _Description = value ?? throw new ArgumentNullException(nameof(value)); 
		}
		public string Url
		{ 
			get => _Url; 
			set => _Url = value ?? throw new ArgumentNullException(nameof(value)); 
		}
		public User User { get; set; }
		#endregion


		#region Constructor
		public Gift(int id, string title, string description, string url, User user)
		{
			Id = id;
			Title = title;
			Description = description;
			Url = url;
			User = user ?? throw new ArgumentNullException(nameof(user));
		}
		public Gift() : this(0, "<default_non-null_title>", "", "", new User())
		{}
		#endregion


		#region Private Helper Methods
		// Reference: https://github.com/IntelliTect-Samples/EWU-CSCD379-2020-Winter/blob/Lecture-2020.01.09/SecretSanta/src/SecretSanta.Business/BlogPost.cs
		private string AssertIsNotNullOrWhitespace(string value)
		{
			return value switch
			{
				null => throw new ArgumentNullException(nameof(value)),
				"" => throw new ArgumentException($"{nameof(value)} cannot be an empty string.", nameof(value)),
				string temp when string.IsNullOrWhiteSpace(temp) =>
					throw new ArgumentException($"{nameof(value)} cannot be only whitespace.", nameof(value)),
				_ => value
			};
		}
		#endregion
	}
}
