using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Common.Attributes
{
    /// <summary>
    /// Custom Validate File Attribute 
    /// Usage: [ValidateFile(AllowedExtensions = "jpg,png,jpeg")]
    /// </summary>
    public class ValidateFileAttribute : ValidationAttribute, IClientModelValidator
    {
        public string AllowedExtensions { get; set; }

        private string errorMessage
        {
            get
            {
                if (string.IsNullOrWhiteSpace(AllowedExtensions))
                {
                    return string.Empty;
                }
                else
                {
                    return "Please upload file of type " + string.Join(", ", AllowedExtensions);
                }
            }
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-allowedextension", string.Join(", ", AllowedExtensions));
            MergeAttribute(context.Attributes, "data-val-validatefile", errorMessage);
        }

        public override bool IsValid(object value)
        {
            if (string.IsNullOrWhiteSpace(AllowedExtensions))
            {
                return true;
            }
            string[] AllowedFileExtensions = AllowedExtensions.Split(",");
            IFormFile file = value as IFormFile;

            if (file == null)
            {
                return true;
            }
            else if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.')).TrimStart('.').ToLower()))
            {
                ErrorMessage = errorMessage;
                return false;
            }
            else
            {
                return true;
            }
        }

        private void MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (attributes.ContainsKey(key))
            {
                return;
            }
            attributes.Add(key, value);
        }
    }
}
