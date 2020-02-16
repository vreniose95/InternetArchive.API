using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using AngleSharp;
using Ccr.Std.Core.Extensions;
using InternetArchive.API.InternetArchive.Domain;
using InternetArchive.API.InternetArchive.Extensions;

namespace InternetArchive.API.InternetArchive.Interpreters
{
  public class IAFileInterpreter
  {
    private const bool _ignoreCare = true;
    private static readonly Regex _dateRegex = new Regex(
      @"(?<year>[0-9]*)-(?<month>[0-9]*)-(?<day>[0-9]*)");


    public static IEnumerable<IAFile> ScrapeArchiveFiles(
	    IAItem internetArchiveItem)
    {
			var context = BrowsingContext.New(
				Configuration.Default.WithDefaultLoader());

			var downloadPageUrl = internetArchiveItem.GetItemDownloadPageUrl();

			using (var document = context
        .OpenAsync(downloadPageUrl)
        .GetAwaiter()
        .GetResult())
      {
        var maincontent = document
          .GetElementById("maincontent");

        var container = maincontent
          .GetElementsByClassName("container-ia")
          .First();

        var directoryListing = container
          .GetElementsByClassName("download-directory-listing")
          .First();

        var tbody = directoryListing
          .GetElementsByTagName("tbody")
          .First();

        var fileNodeList = tbody
          .GetElementsByTagName("tr")
          .Skip(1);

        var itemIndex = 0;

        foreach (var fileNode in fileNodeList)
        {
          var fileLinkElement = fileNode
            .GetElementsByTagName("td")
            .First()
            .GetElementsByTagName("a")
            .First();

          var fileLinkPath = fileLinkElement
            .GetAttribute("href");

          var fileTitle = fileLinkElement
            .TextContent;

          var fileDate = fileNode
            .GetElementsByTagName("td")
            .Skip(1)
            .First()
            .TextContent;

          var fileSize = fileNode
            .GetElementsByTagName("td")
            .Skip(2)
            .First()
            .TextContent;

          var fileKind = DetermineIAFileKind(fileTitle);
					
          //var airDate = DetermineArchiveFileAirDate(
		        //  postShowStr)
	         // .GetValueOrDefault();

          var approximateBytes = DetermineArchiveFileSizeBytes(fileSize);

          if (!DateTime.TryParseExact(
              fileDate,
              "dd-MMM-yyyy ss:mm",
              DateTimeFormatInfo.CurrentInfo,
              DateTimeStyles.None,
              out var lastModifiedDate))
            throw new FormatException(
              $"Cannot parse dateTime from string {fileDate.Quote()}.");

          yield return new IAFile(
	          internetArchiveItem,
						fileLinkPath,
            fileKind,
            fileTitle,
            lastModifiedDate,
						approximateBytes,
            itemIndex);

          itemIndex++;
        }
      }
		}

		public static IEnumerable<IAFile> ScrapeArchiveThumbnailFiles(
			IAItem internetArchiveItem)
		{
			var context = BrowsingContext.New(
				Configuration.Default.WithDefaultLoader());

			var downloadPageUrl = internetArchiveItem.GetItemThumbnailDownloadPageUrl();

			using (var document = context
				.OpenAsync(downloadPageUrl)
				.GetAwaiter()
				.GetResult())
			{
				var maincontent = document
					.GetElementById("maincontent");

				var container = maincontent
					.GetElementsByClassName("container-ia")
					.First();

				var directoryListing = container
					.GetElementsByClassName("download-directory-listing")
					.First();

				var tbody = directoryListing
					.GetElementsByTagName("tbody")
					.First();

				var fileNodeList = tbody
					.GetElementsByTagName("tr")
					.Skip(1);

				var itemIndex = 0;

				foreach (var fileNode in fileNodeList)
				{
					var fileLinkElement = fileNode
						.GetElementsByTagName("td")
						.First()
						.GetElementsByTagName("a")
						.First();

					var fileLinkPath = fileLinkElement
						.GetAttribute("href");

					var fileTitle = fileLinkElement
						.TextContent;

					var fileDate = fileNode
						.GetElementsByTagName("td")
						.Skip(1)
						.First()
						.TextContent;

					var fileSize = fileNode
						.GetElementsByTagName("td")
						.Skip(2)
						.First()
						.TextContent;

					var fileKind = DetermineIAFileKind(fileTitle);

					//var airDate = DetermineArchiveFileAirDate(
					//  postShowStr)
					// .GetValueOrDefault();

					var approximateBytes = DetermineArchiveFileSizeBytes(fileSize);

					if (!DateTime.TryParseExact(
							fileDate,
							"dd-MMM-yyyy ss:mm",
							DateTimeFormatInfo.CurrentInfo,
							DateTimeStyles.None,
							out var lastModifiedDate))
						throw new FormatException(
							$"Cannot parse dateTime from string {fileDate.Quote()}.");

					yield return new IAFile(
						internetArchiveItem,
						fileLinkPath,
						fileKind,
						fileTitle,
						lastModifiedDate,
						approximateBytes,
						itemIndex,
						true);

					itemIndex++;
				}
			}
		}

		public static DateTime? DetermineArchiveFileAirDate(
      string fileName)
    {
      if (!_dateRegex.IsMatch(fileName))
        return null;

      var match = _dateRegex.Match(fileName);

      var yearStr = match.Groups["year"].Value;
      var monthStr = match.Groups["month"].Value;
      var dayStr = match.Groups["day"].Value;

      var year = int.Parse(yearStr);
      var month = int.Parse(monthStr);
      var day = int.Parse(dayStr);

      try
      {
        return new DateTime(
          year,
          month,
          day);
      }
      catch (Exception ex)
      {
        return null;
      }
    }

		/// <summary>
		///   Determines the <see cref="IAFileKind"/> based on the <paramref name="fileName"/> 
		///   parameter's parsed out file extension.
		/// </summary>
		/// <param name="fileName">
		///   The file name as a <see cref="string"/>, including the file extension.
		/// </param>
		/// <returns>
		///   Returns the <see cref="IAFileKind"/> indicating the file extensions type.
		/// </returns>
		public static IAFileKind DetermineIAFileKind(
			string fileName)
    {
      var extension = fileName
	      .Split('.')
	      .Last()
	      .Trim()
	      .ToLower();

      switch (extension)
      {
        case "mp3":
          return IAFileKind.MP3_64Kbps;

        case "mp4":
	        return IAFileKind.MPEG4;

				case "jpeg":
				case "jpg":
          return IAFileKind.JPEG;

				case "pdf":
					return IAFileKind.Text_PDF;

				default:
					return IAFileKind.GetOther(extension);
			}
    }

    private enum DataSizeUnit
    {
      Byte,
      Kilobyte,
      Megabyte,
      Gigabyte
    }

    /// <summary>
    ///   Identifies the <see cref="DataSizeUnit"/> that corresponds with the string label 
    ///   passed through the <paramref name="labelString"/> parameter.
    /// </summary>
    /// <param name="labelString">
    ///   The <see cref="string"/> label suffix that is the data unit.
    /// </param>
    /// <returns>
    ///   Returns a <see cref="DataSizeUnit"/> enum instance indicating the data unit kind. 
    /// </returns>
    private static DataSizeUnit LabelStringToDataSizeUnit(
      string labelString)
    {
      switch (labelString.ToLower().Trim())
      {
        case "b":
          return DataSizeUnit.Byte;

        case "k":
        case "kb":
          return DataSizeUnit.Kilobyte;

        case "m":
        case "mb":
          return DataSizeUnit.Megabyte;

        case "g":
        case "gb":
          return DataSizeUnit.Gigabyte;

        default:
          throw new FormatException(
            $"{labelString.Quote()} cannot be converted to a DataSizeUnit value.");
      }
    }


    public static double DetermineArchiveFileSizeBytes(
      string formattedSize)
    {
      formattedSize = formattedSize.Trim();

      var hasEncounteredDecimal = false;
      var numericStr = "";
      var labelStr = "";

      foreach (var c in formattedSize)
      {
        if (c.IsDigit())
        {
          if (!labelStr.IsNullOrEmptyEx())
            throw new FormatException(
              $"Cannot have digits after letters/label.");

          numericStr += c;
        }
        else if (c == '.')
        {
          if (hasEncounteredDecimal)
            throw new FormatException(
              $"Cannot have more than one decimal point.");

          hasEncounteredDecimal = true;
          numericStr += c;
        }
        else if (c.IsLetter())
        {
          labelStr += c;
        }
        else if (c.IsWhiteSpace())
        {
        }
        else if (c == ',')
        {
        }
        else
        {
	        return 0;
          throw new FormatException(
            $"The character {c.ToString().SQuote()} is not expected.");
        }
      }

      if (!double.TryParse(numericStr, out var numeric))
        throw new FormatException(
          $"{numericStr.Quote()} cannot be parsed to a double.");


      var dataSizeUnit = LabelStringToDataSizeUnit(labelStr);

      switch (dataSizeUnit)
      {
        case DataSizeUnit.Byte:
          return numeric;

        case DataSizeUnit.Kilobyte:
          return numeric * 1024;

        case DataSizeUnit.Megabyte:
          return numeric * 1024 * 1024;

        case DataSizeUnit.Gigabyte:
          return numeric * 1024 * 1024 * 1024;

        default:
          throw new InvalidEnumArgumentException();
      }
    }
  }
}
