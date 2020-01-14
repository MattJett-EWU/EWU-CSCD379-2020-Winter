using System;
using System.Collections.Generic;

namespace SecretSanta.Business
{
	public class User
	{
		#region Fields
		private string _FirstName = "";
		private string _LastName = "";
		#endregion

		#region Properties
		public int Id { get; }
		public string FirstName 
		{ 
			get => _FirstName; 
			set => _FirstName = AssertIsNotNullOrWhitespace(value); 
		}
		public string LastName 
		{ 
			get => _LastName; 
			set => _LastName = AssertIsNotNullOrWhitespace(value); 
		}
		public List<Gift> Gifts { get; }
		#endregion

		#region Constructor
		public User(int id, string fname, string lname, List<Gift> gifts)
		{
			Id = id;
			FirstName = fname;
			LastName = lname;
			Gifts = gifts ?? throw new ArgumentNullException(nameof(gifts));
		}
		public User() : this(0, "<default_non-null_firstname>", "<default_non-null_lastname>", new List<Gift>())
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
