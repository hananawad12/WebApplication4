﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WeddingGo.Helpers
{
	public static class Extensions
	{
		public static void AddApplicationError(this HttpResponse response, string Message)
		{
			response.Headers.Add("Application-Error", Message);
			response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");

			response.Headers.Add("Access-Control-Allow-Origin", "*");


		}


		public static int CalcAge(this DateTime theDateTime)
		{
			var age = DateTime.Today.Year - theDateTime.Year;
			if (theDateTime.AddYears(age) > DateTime.Today)
				age--;
			return age;
		}
	}
}
