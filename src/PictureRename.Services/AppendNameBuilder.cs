using System;
using PictureRename.Services.Interfaces;

namespace PictureRename.Services
{
    public class AppendNameBuilder : INameBuilder
    {
         public string GetFileName(string originalName, DateTime date)
         {
               return date.ToString("yyyyMM_ddHHmmss_") + originalName;
         }
    }
}