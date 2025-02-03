using System;
using System.ComponentModel.DataAnnotations;

namespace M2M_EF.Models;

public class FileModel
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public long Size { get; set; }
    public string FullPath { get; set; }
    public int FolderId { get; set; }
    public FolderModel Folder { get; set; }
}