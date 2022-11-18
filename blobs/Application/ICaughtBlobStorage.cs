﻿using blobs.Domain;

namespace blobs.Application;

public interface ICaughtBlobStorage
{
    void AddBlob(CaughtBlobModel blob);
    IEnumerable<CaughtBlobModel> GetBlobModels(IEnumerable<Guid> ids);
}