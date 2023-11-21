using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TbcTask.Domain.Models.Exceptions;
using TbcTask.Domain.Models.Resources;

namespace TbcTask.Infrastructure.Services.Helper.FileManager
{
    public static class FileManager
    {
        public static string StoreFileOnServer(IFormFile file,string path)
        {
            var fileNameGenerate = $"{Guid.NewGuid().ToString()}_{file.FileName}";
            var directory = Path.Combine(path, "Uploads");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            var uploadsFolder = Path.Combine(directory, fileNameGenerate);
            using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return uploadsFolder;

        }
        public static string GetFileFromServer(string path, string fileName)
        {
                    string uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

                    string imagePath = Path.Combine(uploadsFolderPath, fileName);

                    if (System.IO.File.Exists(imagePath))
                    {
                        byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);
                        string base64String = Convert.ToBase64String(imageBytes);
                if (fileName.ToUpper().EndsWith(".PNG"))
                {
                    return $"data:image/png;base64,{base64String}";
                }
                if (fileName.ToUpper().EndsWith(".JPG")||fileName.ToUpper().EndsWith(".JPEG"))
                {
                    return $"data:image/jpeg;base64,{base64String}";
                }
                else
                {
                    throw new ApiException(ErrorResponses.IncorrectFormat);
                }
            }
            else
            {
                throw new ApiException(ErrorResponses.FileNotFound);
            }

            }
        }
    }
