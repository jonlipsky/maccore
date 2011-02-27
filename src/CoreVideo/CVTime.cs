// 
// CVTime.cs
//
// Authors: Mono Team
//     
// Copyright 2011 Novell, Inc
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using MonoMac.CoreFoundation;
using MonoMac.ObjCRuntime;

namespace MonoMac.CoreVideo {
	public struct CVTime {
		public Int64 TimeValue;
		public Int64 TimeScale;
		public Int32 Flags;

		/* FIXME:
		 * 
		 * These are global constant structures, so we need to extend Dlfcn to handle this.
		 *
		 * const CVTime kCVZeroTime;
		 * const CVTime kCVIndefiniteTime;
		 */
                public override bool Equals (object other)
                {
                        if (!(other is CVTime))
                                return false;

			CVTime b = (CVTime) other;

			return (TimeValue == b.TimeValue) && (TimeScale == b.TimeScale) && (Flags == b.Flags);
                }

		[DllImport (Constants.CoreVideoLibrary, EntryPoint = "CVGetCurrentHostTime")]
		public static extern Int64 GetCurrentHostTime ();
		[DllImport (Constants.CoreVideoLibrary, EntryPoint = "CVGetHostClockFrequency")]
		public static extern double GetHostClockFrequency ();
		[DllImport (Constants.CoreVideoLibrary, EntryPoint = "CVGetHostClockMinimumTimeDelta")]
		public static extern int GetHostClockMinimumTimeDelta ();
	}
}