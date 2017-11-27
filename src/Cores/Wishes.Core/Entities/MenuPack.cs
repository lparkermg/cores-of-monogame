using System;
using System.Collections.Generic;
using System.Text;

namespace Wishes.Core.Entities
{
    [DataContract(Namespace = "PackMaker")]
    public class MenuPack
    {
        //TODO: Maybe add a bgm track to this?
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Type { get; set; }
        //TODO: Change to a dictionary which would how the commands
        [DataMember]
        public List<string> Items { get; set; }
        [DataMember]
        public int Layout { get; set; }
        //TODO: Maybe a dictionary with the images in it would be better.
        [DataMember]
        public ImageData BackgroundImage { get; set; }
        [DataMember]
        public ImageData Logo { get; set; }
        [DataMember]
        public string CopyrightText { get; set; }

        public MenuPack() { }

        public MenuPack(string name, int type, List<string> items, int layout, ImageData backgroundImage, ImageData logo, string copyrightText)
        {
            Name = name;
            Type = type;
            Items = items;
            Layout = layout;
            BackgroundImage = backgroundImage;
            Logo = logo;
            CopyrightText = copyrightText;
        }

        public bool IsValid()
        {
            if (String.IsNullOrWhiteSpace(Name))
                return false;

            if (Type < 0)
                return false;

            if (Items == null)
                return false;

            if (Items.Count == 0)
                return false;

            if (Layout < 0)
                return false;

            var bkgSuccess = ImageValidation(BackgroundImage);

            if (!bkgSuccess)
                return false;

            return true;
        }

        private bool ImageValidation(ImageData image)
        {
            if (image == null)
                return false;

            if (image.Height == 0)
                return false;

            if (image.Width == 0)
                return false;

            var byteCheck = ByteArrayValidation(image.Data);

            if (!byteCheck)
                return false;

            return true;
        }

        private bool ByteArrayValidation(byte[] array)
        {
            if (array == null)
                return false;

            if (array.Length == 0)
                return false;

            return true;
        }
    }

    [DataContract(Namespace = "PackMaker")]
    public class AudioData
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public byte[] Data { get; set; }

        public AudioData() { }

        public AudioData(int id, byte[] data)
        {
            Id = id;
            Data = data;
        }
    }

    [DataContract(Namespace = "PackMaker")]
    public class ImageData
    {
        [DataMember]
        public int Height { get; set; }
        [DataMember]
        public int Width { get; set; }
        [DataMember]
        public byte[] Data { get; set; }

        public ImageData() { }

        public ImageData(int height, int width, byte[] data)
        {
            Height = height;
            Width = width;
            Data = data;
        }
    }
}
