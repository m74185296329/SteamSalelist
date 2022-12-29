using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace SteamSalelist;

public class DataTableGeneration
{
	private DataTable dataTable;

	public DataTableGeneration() { }

	public DataTable DataTableToGenerate{
		get { return dataTable; }   // get method
		set { dataTable = value; }  // set method
	}
	#region JSON Properties
	public partial class SteamGames
	{
		[JsonProperty("applist")]
		public Applist Applist { get; set; }
	}

	public partial class Applist
	{
		[JsonProperty("apps")]
		public App[] Apps { get; set; }
	}

	public partial class App
	{
		[JsonProperty("appid")]
		public long Appid { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
	#endregion
	public static DataTable GetJSONToDataTableUsingMethod(SteamGames steamGames)
	{
		DataTable dt = new DataTable();
		dt.Columns.Add("Name", typeof(String));
		dt.Columns.Add("AppId", typeof(int));

		foreach (var item in steamGames.Applist.Apps)
		{
			dt.Rows.Add(item.Name, item.Appid);
		}
		
		return dt;
	}

}