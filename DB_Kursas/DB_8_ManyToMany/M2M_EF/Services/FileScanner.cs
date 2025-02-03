using System;
using M2M_EF.Models;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace M2M_EF.Services;

public class FileScanner
{
    private readonly Dictionary<string, FolderModel> _processedFolders = new();
    
    public (List<FileModel> files, List<FolderModel> folders) ScanDirectory(string directoryPath)
    {
        var files = new List<FileModel>();
        var folders = new List<FolderModel>();

        if (string.IsNullOrEmpty(directoryPath))
        {
            throw new ArgumentNullException(nameof(directoryPath));
        }

        if (!Directory.Exists(directoryPath))
        {
            throw new DirectoryNotFoundException($"Directory not found: {directoryPath}");
        }

        try
        {
            ScanFolder(directoryPath, null, files, folders);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error scanning directory: {ex.Message}");
            throw;
        }

        return (files, folders);
    }

    private void ScanFolder(string folderPath, FolderModel? parentFolder, List<FileModel> files, List<FolderModel> folders)
    {
        var folderInfo = new DirectoryInfo(folderPath);

        // var folderModel = new FolderModel();

        // if (folderModel.ParentFolder != null)
        // {
        //     folderModel.ParentFolderId = parentFolder.Id;
        // }

        // if (parentFolder == null)
        // {
        //     folderModel.ParentFolderId = null;
        // }
        // else
        // {
        //     folderModel.ParentFolderId = parentFolder.Id;
        // }

        var folder = new FolderModel
        {
            Name = folderInfo.Name,
            FullPath = folderInfo.FullName,
            ParentFolderId = parentFolder?.Id // FIX ME
        };
        

        folders.Add(folder);
        _processedFolders[folder.FullPath] = folder;

        foreach (var fileInfo in folderInfo.GetFiles())
        {
            var file = new FileModel
            {
                Name = fileInfo.Name,
                Size = fileInfo.Length,
                FullPath = fileInfo.FullName,
                FolderId = folder.Id
            };
            files.Add(file);
        }

        foreach (var subFolderInfo in folderInfo.GetDirectories())
        {
            ScanFolder(subFolderInfo.FullName, folder, files, folders);
        }
    }
}
