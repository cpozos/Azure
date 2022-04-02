namespace Azure.Models
{
    public class BlobInfoModel
    {
        public BinaryData Data { get; }
        public string ContentType { get; }

        public BlobInfoModel(BinaryData data, string contentType)
        {
            Data = data;
            ContentType = contentType;
        }
    }
}
