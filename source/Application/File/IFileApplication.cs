using DotNetCore.Objects;
using System;
using System.Collections.Generic;

namespace IDCardScanning.Application
{
    public interface IFileApplication
    {
        IEnumerable<FileBinary> Save(string directory, IEnumerable<FileBinary> files);

        FileBinary Select(string directory, Guid id);
    }
}
