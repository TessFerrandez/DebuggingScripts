using System;
using System.Drawing;

namespace MemoryDisplay
{
    public enum State { Free, Commit, Reserve, Undefined };
    public enum Usage { VirtualAlloc, Free, Image, Stack, TEB, Heap, PageHeap, PEB, ProcessParameters, EnvironmentBlock, Undefined, GCHeap };

    public class MemoryRegion
    {
        public Int64 Address { get; internal set; }
        public Int64 Size { get; internal set; }
        public Usage Usage { get; internal set; }
        public State State { get; internal set; }

        public MemoryRegion()
        {
            State = State.Undefined;
            Usage = Usage.Undefined;
            Address = -1;
            Size = 0;
        }

        public MemoryRegion(long address, long size, State state, Usage usage)
        {
            Address = address;
            Size = size;
            State = state;
            Usage = usage;
        }

        public Color GetColor()
        {
            if (State == State.Undefined)
                return Color.Gray;
            if (Usage == Usage.Free)
                return Color.White;

            if (Usage == Usage.EnvironmentBlock || Usage == Usage.PEB || Usage == Usage.ProcessParameters || Usage == Usage.TEB || Usage == Usage.Stack)
            {
                if (State == State.Commit)
                    return Color.Purple;
                else
                    return Color.Pink;
            }

            if (Usage == Usage.Heap)
            {
                if (State == State.Commit)
                    return Color.Blue;
                else
                    return Color.LightBlue;
            }

            if (Usage == Usage.Image)
            {
                if (State == State.Commit)
                    return Color.DarkRed;
                else
                    return Color.Red;
            }

            if (Usage == Usage.VirtualAlloc)
            {
                if (State == State.Commit)
                    return Color.Green;
                else
                    return Color.GreenYellow;
            }

            if (Usage == Usage.PageHeap)
            {
                if (State == State.Commit)
                    return Color.Black;
                else
                    return Color.DarkSlateGray;
            }

            if (Usage == Usage.GCHeap)
            {
                if (State == State.Commit)
                    return Color.Green;
                else
                    return Color.GreenYellow;
            }

            return Color.Gray;
        }
    }
}
