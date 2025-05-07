using System;

namespace FontStashSharp.Interfaces
{
	// Token: 0x02000003 RID: 3
	public interface IFontLoader
	{
		IFontSource Load(byte[] data);
	}
}
