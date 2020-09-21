using System;

namespace PictureRename.Services.Interfaces
{
    public interface INameBuilder
    {
         string GetFileName(string originalName, DateTime date);
    }
}