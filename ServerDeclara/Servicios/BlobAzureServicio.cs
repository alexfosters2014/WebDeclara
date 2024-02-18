using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using iText.IO.Image;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.IO;




namespace ServerDeclara.Servicios
{
    public class BlobAzureServicio
    {
        private string _extension = ".pdf";
        private readonly IConfiguration _configuration;
        private string conexionAzureBlob;
        private string nombreStorageBlob;

        public BlobAzureServicio(IConfiguration configuration)
        {
            _configuration = configuration;
            conexionAzureBlob = _configuration["AzureBlobStorage:ConexionAzureBlob"];
            nombreStorageBlob = _configuration["AzureBlobStorage:NombreStorageBlob"];
        }

        public async Task<string> SubirImagen(IBrowserFile imagenStream)
        {
            try
            {
              

                await using var memoryStreamImagen = new MemoryStream();
                await imagenStream.OpenReadStream(maxAllowedSize: imagenStream.Size).CopyToAsync(memoryStreamImagen);
                memoryStreamImagen.Position = 0;

                string imageName = Guid.NewGuid().ToString() + _extension;

                BlobContainerClient blobContainer = new BlobContainerClient(conexionAzureBlob, nombreStorageBlob);
                BlobClient blob = blobContainer.GetBlobClient(imageName);

                await blob.UploadAsync(memoryStreamImagen);

                return imageName;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> ActualizarImagen(IFormFile imagenStream, string nombreArchivoAnterior)
        {
            try
            {

                await using var memoryStreamImagen = new MemoryStream();
                await imagenStream.CopyToAsync(memoryStreamImagen);
                memoryStreamImagen.Position = 0;

                string imageName = Guid.NewGuid().ToString() + _extension;

                BlobContainerClient blobContainer = new BlobContainerClient(conexionAzureBlob, nombreStorageBlob);


                BlobClient blobAEliminar = blobContainer.GetBlobClient(nombreArchivoAnterior);
                await EliminarImagen(blobAEliminar);


                BlobClient blob = blobContainer.GetBlobClient(imageName);
                await blob.UploadAsync(memoryStreamImagen);

                return imageName;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private async Task EliminarImagen(BlobClient blob)
        {
            try
            {
                await blob.DeleteAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }



        public async Task<string> SubirPDF(byte[] pdfStream)
        {
            try
            {
                string pdfName = string.Empty;

               var pdfDataBinario = new BinaryData(pdfStream);

                pdfName = Guid.NewGuid().ToString() + _extension;

                BlobContainerClient blobContainer = new BlobContainerClient(conexionAzureBlob, nombreStorageBlob);
                BlobClient blob = blobContainer.GetBlobClient(pdfName);

                await blob.UploadAsync(pdfDataBinario);

                return pdfName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<byte[]> ObtenerPDF(string pdfNombre)
        {
            try
            {
                BlobContainerClient blobContainer = new BlobContainerClient(conexionAzureBlob, nombreStorageBlob);
                BlobClient blob = blobContainer.GetBlobClient(pdfNombre);

                BlobDownloadResult downloadResult = await blob.DownloadContentAsync();

                using MemoryStream stream = new MemoryStream();

                byte[] pdfByte = downloadResult.Content.ToArray();

                //string PdfUrl = Convert.ToBase64String(pdfByte);

                return pdfByte;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }




    }
}
