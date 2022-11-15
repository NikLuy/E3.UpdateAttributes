using System.Collections.Generic;
using System.Linq;
using E3.UpdateAttributes.Interfaces.Logic;

namespace E3.UpdateAttributes.Logic
{
    public class SelectionItems : ISelectionItems
    {
        public SelectionType SelectionType { get; set; }
        public void AddItem(int itemId, int itemType)
        {
            switch (itemType)
            {
                case (int)E3ItemType.Job: Jobs.Add(itemId); break;
                case (int)E3ItemType.Component: Components.Add(itemId); break;
                case (int)E3ItemType.SymbolType: SymbolTypes.Add(itemId); break;
                case (int)E3ItemType.Device: Devices.Add(itemId); break;
                case (int)E3ItemType.Gate: Gates.Add(itemId); break;
                case (int)E3ItemType.DevicePin: DevicePins.Add(itemId); break;
                case (int)E3ItemType.Block: Blocks.Add(itemId); break;
                case (int)E3ItemType.BlockConnector: BlockConnectors.Add(itemId); break;
                case (int)E3ItemType.BlockConnectorPin: BlockConnectorPins.Add(itemId); break;
                case (int)E3ItemType.ConnectorFree: ConnectorFrees.Add(itemId); break;
                case (int)E3ItemType.ConnectorPin: ConnectorPins.Add(itemId); break;
                case (int)E3ItemType.Cable: Cables.Add(itemId); break;
                case (int)E3ItemType.WireCore: WireCores.Add(itemId); break;
                case (int)E3ItemType.Signal: Signals.Add(itemId); break;
                case (int)E3ItemType.Attribute: Attributes.Add(itemId); break;
                case (int)E3ItemType.Sheet: Sheets.Add(itemId); break;
                case (int)E3ItemType.CellPlacedSymbol: CellPlacedSymbols.Add(itemId); break;
                case (int)E3ItemType.Text: Texts.Add(itemId); break;
                case (int)E3ItemType.Line: Lines.Add(itemId); break;
                case (int)E3ItemType.Node: Nodes.Add(itemId); break;
                case (int)E3ItemType.Graphic: Graphics.Add(itemId); break;
                case (int)E3ItemType.Net: Nets.Add(itemId); break;
                case (int)E3ItemType.NetSegment: NetSegments.Add(itemId); break;
                case (int)E3ItemType.Bundle: Bundles.Add(itemId); break;
                case (int)E3ItemType.CableType: CableTypes.Add(itemId); break;
                case (int)E3ItemType.WireType: WireTypes.Add(itemId); break;
                case (int)E3ItemType.Outline: Outlines.Add(itemId); break;
                case (int)E3ItemType.Connection: Connections.Add(itemId); break;
                case (int)E3ItemType.StructureNode: StructureNodes.Add(itemId); break;
            }
        }

        public void ClearAll()
        {
            Jobs.Clear();
            Components.Clear();
            SymbolTypes.Clear();
            Devices.Clear();
            Gates.Clear();
            DevicePins.Clear();
            Blocks.Clear();
            BlockConnectors.Clear();
            BlockConnectorPins.Clear();
            ConnectorFrees.Clear();
            ConnectorPins.Clear();
            Cables.Clear();
            WireCores.Clear();
            Signals.Clear();
            Attributes.Clear();
            Sheets.Clear();
            CellPlacedSymbols.Clear();
            Texts.Clear();
            Lines.Clear();
            Nodes.Clear();
            Graphics.Clear();
            Nets.Clear();
            NetSegments.Clear();
            Bundles.Clear();
            CableTypes.Clear();
            WireTypes.Clear();
            Outlines.Clear();
            Connections.Clear();
            StructureNodes.Clear();
        }

  

        public List<int> Jobs { get; set; } = new List<int>();
        public List<int> Components { get; set; } = new List<int>();
        public List<int> SymbolTypes { get; set; } = new List<int>();
        public List<int> Devices { get; set; } = new List<int>();
        public List<int> Gates { get; set; } = new List<int>();
        public List<int> DevicePins { get; set; } = new List<int>();
        public List<int> Blocks { get; set; } = new List<int>();
        public List<int> BlockConnectors { get; set; } = new List<int>();
        public List<int> BlockConnectorPins { get; set; } = new List<int>();
        public List<int> ConnectorFrees { get; set; } = new List<int>();
        public List<int> ConnectorPins { get; set; } = new List<int>();
        public List<int> Cables { get; set; } = new List<int>();
        public List<int> WireCores { get; set; } = new List<int>();
        public List<int> Signals { get; set; } = new List<int>();
        public List<int> Attributes { get; set; } = new List<int>();
        public List<int> Sheets { get; set; } = new List<int>();
        public List<int> CellPlacedSymbols { get; set; } = new List<int>();
        public List<int> Texts { get; set; } = new List<int>();
        public List<int> Lines { get; set; } = new List<int>();
        public List<int> Nodes { get; set; } = new List<int>();
        public List<int> Graphics { get; set; } = new List<int>();
        public List<int> Nets { get; set; } = new List<int>();
        public List<int> NetSegments { get; set; } = new List<int>();
        public List<int> Bundles { get; set; } = new List<int>();
        public List<int> CableTypes { get; set; } = new List<int>();
        public List<int> WireTypes { get; set; } = new List<int>();
        public List<int> Outlines { get; set; } = new List<int>();
        public List<int> Connections { get; set; } = new List<int>();
        public List<int> StructureNodes { get; set; } = new List<int>();

        public int TotalTreeSelectionItemCount { get; }
        public int TotalSheetSelectionItemCount { get; }
        public bool ValidSelection { get; }
        public string SelectionInfo { get; }
    }
}