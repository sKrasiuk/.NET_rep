using System;
using System.ComponentModel.DataAnnotations;

namespace M2M_EF.Models;

public class FolderModel
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string FullPath { get; set; }
    public int? ParentFolderId { get; set; }
    // public FolderModel? ParentFolder { get; set; }
    // public ICollection<FolderModel> SubFolders { get; set; } = new List<FolderModel>();
    public ICollection<FileModel> Files { get; set; } = new List<FileModel>();
}
