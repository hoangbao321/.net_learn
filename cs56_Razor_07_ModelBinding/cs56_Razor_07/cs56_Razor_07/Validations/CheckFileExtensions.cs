using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;



[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public sealed class CheckFileExtensions : DataTypeAttribute
{
    private string _extensions;

    public CheckFileExtensions()
        : base(DataType.Upload)
    {

        // DevDiv 468241: set DefaultErrorMessage not ErrorMessage, allowing user to set
        // ErrorMessageResourceType and ErrorMessageResourceName to use localized messages.
        ErrorMessage = "nhap dung dinh dang jpg, png";
    }

    public string Extensions
    {
        get
        {
            // Default file extensions match those from jquery validate.
            return String.IsNullOrWhiteSpace(_extensions) ? "png,jpg,jpeg,gif" : _extensions;
        }
        set
        {
            _extensions = value;
        }
    }

    private string ExtensionsFormatted
    {
        get
        {
            return ExtensionsParsed.Aggregate((left, right) => left + ", " + right);
        }
    }

    [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase", Justification = "These strings are normalized to lowercase because they are presented to the user in lowercase format")]
    private string ExtensionsNormalized
    {
        get
        {
            return Extensions.Replace(" ", "").Replace(".", "").ToLowerInvariant();
        }
    }

    private IEnumerable<string> ExtensionsParsed
    {
        get
        {
            return ExtensionsNormalized.Split(',').Select(e => "." + e);
        }
    }

    public override string FormatErrorMessage(string name)
    {
        return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, ExtensionsFormatted);
    }

    public override bool IsValid(object value)
    {
        if (value == null)
        {
            return true;
        }
	
	// check uploads nhiều file và check xem true hay false
	// //https://github.com/microsoft/referencesource/blob/master/System.ComponentModel.DataAnnotations/DataAnnotations/FileExtensionsAttribute.cs
        IFormFile[] file = value as IFormFile[];
        if (file.Count() > 0)
        {
            var filename = "";
            foreach (var f in file)
            {
                filename = f.FileName;
                var check_file = ValidateExtension(filename);
                if(check_file == false)
                {
                    return ValidateExtension(filename);
                }
            }
            return ValidateExtension(filename);
        }



        string valueAsString = value as string;
        if (valueAsString != null)
        {
            return ValidateExtension(valueAsString);
        }

        return false;
    }

    [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase", Justification = "These strings are normalized to lowercase because they are presented to the user in lowercase format")]
    private bool ValidateExtension(string fileName)
    {
        try
        {
            return ExtensionsParsed.Contains(Path.GetExtension(fileName).ToLowerInvariant());
        }
        catch (ArgumentException)
        {
            return false;
        }
    }
}
