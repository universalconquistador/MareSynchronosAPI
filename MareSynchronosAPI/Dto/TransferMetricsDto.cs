using MareSynchronos.API.Data;
using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MareSynchronos.API.Dto;

[MessagePackObject(keyAsPropertyName: true)]
public record TransferMetricsDto(int UtcOffsetMinutes, ulong DownloadedFileBytes, double DownloadedFileSeconds, ulong UploadedFileBytes, double UploadedFileSeconds);
