        byte[] array = File.ReadAllBytes(path);
        StringBuilder stringBuilder = new StringBuilder();
        byte[] array2 = array;
        for (int i = 0; i < array2.Length; i++)
        {
            byte b = array2[i];
            stringBuilder.Append(b.ToString() + " ");
        }
        string contents = stringBuilder.ToString().Remove(stringBuilder.ToString().Length - 1);
