using AoC_D5.MathUtil;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AoC_D5_Tests
{
    [TestClass]
    public class SpanTests
    {
        [TestMethod]
        public void Span_Test1_LengthProperty()
        {
            ISpan span = new Span { Start = 5, End = 10 };
            Assert.AreEqual(6, span.Length);
        }

        [TestMethod]
        public void Span_Test2_EndProperty()
        {
            ISpan span = new Span { Start = 5, Length = 10 };
            Assert.AreEqual(14, span.End);
        }

        [TestMethod]
        public void Span_Test4_GetOverlap_NoOverlap()
        {
            ISpan knife = new Span { Start = 5, End = 10 };
            ISpan target = new Span { Start = 15, End = 25 };
            (ISpan Overlap, List<ISpan> Extra) chopped = knife.GetOverlap(target);

            Assert.IsNull(chopped.Overlap);
            Assert.AreEqual(1, chopped.Extra.Count);
            Assert.AreEqual(15, chopped.Extra[0].Start);
            Assert.AreEqual(25, chopped.Extra[0].End);
        }

        [TestMethod]
        public void Span_Test4_GetOverlap_NoOverlap2()
        {
            ISpan knife = new Span { Start = 15, End = 25 }; // order swapped
            ISpan target = new Span { Start = 5, End = 10 };
            (ISpan Overlap, List<ISpan> Extra) chopped = knife.GetOverlap(target);

            Assert.IsNull(chopped.Overlap);
            Assert.AreEqual(1, chopped.Extra.Count);
            Assert.AreEqual(5, chopped.Extra[0].Start);
            Assert.AreEqual(10, chopped.Extra[0].End);
        }

        [TestMethod]
        public void Span_Test4_GetOverlap_Overlap1()
        {
            ISpan knife = new Span { Start = 5, End = 15 };
            ISpan target = new Span { Start = 10, End = 25 };
            (ISpan Overlap, List<ISpan> Extra) chopped = knife.GetOverlap(target);

            Assert.AreEqual(10, chopped.Overlap.Start);
            Assert.AreEqual(15, chopped.Overlap.End);

            Assert.AreEqual(1, chopped.Extra.Count);
            Assert.AreEqual(16, chopped.Extra[0].Start);
            Assert.AreEqual(25, chopped.Extra[0].End);
        }

        [TestMethod]
        public void Span_Test4_GetOverlap_Overlap2()
        {
            ISpan knife = new Span { Start = 10, End = 25 };
            ISpan target = new Span { Start = 5, End = 15 };
            (ISpan Overlap, List<ISpan> Extra) chopped = knife.GetOverlap(target);

            Assert.AreEqual(10, chopped.Overlap.Start);
            Assert.AreEqual(15, chopped.Overlap.End);

            Assert.AreEqual(1, chopped.Extra.Count);
            Assert.AreEqual(5, chopped.Extra[0].Start);
            Assert.AreEqual(9, chopped.Extra[0].End);
        }

        [TestMethod]
        public void Span_Test4_GetOverlap_TotalOverlap1()
        {
            ISpan knife = new Span { Start = 5, End = 25 };
            ISpan target = new Span { Start = 10, End = 15 };
            (ISpan Overlap, List<ISpan> Extra) chopped = knife.GetOverlap(target);

            Assert.AreEqual(10, chopped.Overlap.Start);
            Assert.AreEqual(15, chopped.Overlap.End);

            Assert.AreEqual(0, chopped.Extra.Count);
        }

        [TestMethod]
        public void Span_Test4_GetOverlap_TotalOverlap2()
        {
            ISpan knife = new Span { Start = 10, End = 15 };
            ISpan target = new Span { Start = 5, End = 25 };
            (ISpan Overlap, List<ISpan> Extra) chopped = knife.GetOverlap(target);

            Assert.AreEqual(10, chopped.Overlap.Start);
            Assert.AreEqual(15, chopped.Overlap.End);

            Assert.AreEqual(2, chopped.Extra.Count);
            Assert.AreEqual(5, chopped.Extra[0].Start);
            Assert.AreEqual(9, chopped.Extra[0].End);
            Assert.AreEqual(16, chopped.Extra[1].Start);
            Assert.AreEqual(25, chopped.Extra[1].End);
        }

        [TestMethod]
        public void Span_Test4_GetOverlap_Equal()
        {
            ISpan knife = new Span { Start = 10, End = 15 };
            ISpan target = new Span { Start = 10, End = 15 };
            (ISpan Overlap, List<ISpan> Extra) chopped = knife.GetOverlap(target);

            Assert.AreEqual(10, chopped.Overlap.Start);
            Assert.AreEqual(15, chopped.Overlap.End);

            Assert.AreEqual(0, chopped.Extra.Count);
        }
    }
}
