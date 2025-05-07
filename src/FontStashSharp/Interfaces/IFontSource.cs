using System;

namespace FontStashSharp.Interfaces
{
	public interface IFontSource : IDisposable
	{
		void GetMetricsForSize(float fontSize, out int ascent, out int descent, out int lineHeight);

		int? GetGlyphId(int codepoint);

		void GetGlyphMetrics(int glyphId, float fontSize, out int advance, out int x0, out int y0, out int x1, out int y1);

		void RasterizeGlyphBitmap(int glyphId, float fontSize, byte[] buffer, int startIndex, int outWidth, int outHeight, int outStride);

		int GetGlyphKernAdvance(int previousGlyphId, int glyphId, float fontSize);
	}
}
