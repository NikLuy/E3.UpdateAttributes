using System.Collections.Generic;

namespace E3.UpdateAttributes.Interfaces.Logic
{
    public enum E3ItemType
    {
        Job = 1,
        Component = 2,
        SymbolType = 5,
        Device = 10,
        Gate = 11,
        DevicePin = 12,
        Block = 13,
        BlockConnector = 14,
        BlockConnectorPin = 16,
        ConnectorFree = 17,
        ConnectorPin = 19,
        Cable = 20,
        WireCore = 22,
        Signal = 24,
        Attribute = 27,
        Sheet = 28,
        CellPlacedSymbol = 30,
        Text = 31,
        Line = 32,
        Node = 33,
        Graphic = 34,
        Net = 38,
        NetSegment = 39,
        Bundle = 50,
        CableType = 51,
        WireType = 52,
        Outline = 60,
        Connection = 143,
        StructureNode = 180
    }

    public enum SelectionType
    {
        Unknown,
        Tree,
        Sheet
    }
    public interface ISelectionItems
    {
        SelectionType SelectionType { get; set; }

        void AddItem(int itemId, int itemType);
        void ClearAll();
        List<int> Jobs { get; set; }
        List<int> Components { get; set; }
        List<int> SymbolTypes { get; set; }
        List<int> Devices { get; set; }
        List<int> Gates { get; set; }
        List<int> DevicePins { get; set; }
        List<int> Blocks { get; set; }
        List<int> BlockConnectors { get; set; }
        List<int> BlockConnectorPins { get; set; }
        List<int> ConnectorFrees { get; set; }
        List<int> ConnectorPins { get; set; }
        List<int> Cables { get; set; }
        List<int> WireCores { get; set; }
        List<int> Signals { get; set; }
        List<int> Attributes { get; set; }
        List<int> Sheets { get; set; }
        List<int> CellPlacedSymbols { get; set; }
        List<int> Texts { get; set; }
        List<int> Lines { get; set; }
        List<int> Nodes { get; set; }
        List<int> Graphics { get; set; }
        List<int> Nets { get; set; }
        List<int> NetSegments { get; set; }
        List<int> Bundles { get; set; }
        List<int> CableTypes { get; set; }
        List<int> WireTypes { get; set; }
        List<int> Outlines { get; set; }
        List<int> Connections { get; set; }
        List<int> StructureNodes { get; set; }
        int TotalTreeSelectionItemCount { get; }
        int TotalSheetSelectionItemCount { get; }
        bool ValidSelection { get; }
        string SelectionInfo { get; }
    }
}