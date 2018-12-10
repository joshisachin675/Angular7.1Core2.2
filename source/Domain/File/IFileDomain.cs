using DotNetCore.Objects;
using System;
using System.Collections.Generic;

namespace IDCardScanning.Domain
{
    public interface IFileDomain
    {
        IEnumerable<FileBinary> Save(string directory, IEnumerable<FileBinary> files);

        FileBinary Select(string directory, Guid id);
    }
}
