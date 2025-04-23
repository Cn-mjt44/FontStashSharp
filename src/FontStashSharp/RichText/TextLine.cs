using System.Collections.Generic;

#if MONOGAME || FNA
using Microsoft.Xna.Framework;
#elif STRIDE
using Stride.Core.Mathematics;
#else
using System.Drawing;
#endif

namespace FontStashSharp.RichText
{
	public class TextLine
	{
		public int Count { get; internal set; }

		public Point Size;

		public int LineIndex { get; internal set; }

		public int TextStartIndex { get; internal set; }

		public List<BaseChunk> Chunks { get; } = new List<BaseChunk>();

		public TextChunkGlyph? GetGlyphInfoByIndex(int index)
		{
			foreach (var chunk in Chunks)
			{
				var textChunk = chunk as TextChunk;
				if (textChunk == null) continue;

				if (index >= textChunk.Count)
				{
					index -= textChunk.Count;
				}
				else
				{
					return textChunk.GetGlyphInfoByIndex(index);
				}
			}

			return null;
		}


		public BaseChunk GetBaseChunkByX(int x)
		{
			if (Chunks.Count == 0)
			{
				return null;
			}

			for (var i = 0; i < Chunks.Count; ++i)
			{
				var chunk = Chunks[i];
				if (x >= chunk.Size.X)
				{
					x -= chunk.Size.X;
				}
				else
				{
					return chunk;
				}
			}

			return null;
		}
	}
}
