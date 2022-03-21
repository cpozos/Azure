namespace Azure.Models
{
    public class BlobInfo
    {
        public BinaryData Data { get; }
        public string ContentType { get; }

        public BlobInfo(BinaryData data, string contentType)
        {
            Data = data;
            ContentType = contentType;
        }
    }
}
