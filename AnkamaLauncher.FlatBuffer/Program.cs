using System.Text.Json;
using Google.FlatBuffers;

var httpClient = new HttpClient();
var metaFile = await httpClient.GetByteArrayAsync("https://cytrus.cdn.ankama.com/dofus/releases/main/windows/6.0_2.66.1.8.manifest");

var test = Manifest.GetRootAsManifest(new ByteBuffer(metaFile));
Console.WriteLine(test.FragmentsLength);

var mt = test.UnPack();

System.IO.File.WriteAllText("manifest.json", JsonSerializer.Serialize(mt, new JsonSerializerOptions() { WriteIndented = true}));