using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoProcessor.Editing.Layers;

namespace PhotoProcessor.Editing.Collections
{
    public class ProjectLayerCollection : ChildrenCollection<Project, Layer>
    {
        public ProjectLayerCollection(Project owner) : base(owner)
        {
        }

        public NormalLayer AddNewNormalLayer()
        {
            var newLayer = new NormalLayer(Owner);
            Add(newLayer);

            return newLayer;
        }

        public LayerGroup AddNewLayerGroup()
        {
            var layerGroup = new LayerGroup(Owner);
            Add(layerGroup);

            return layerGroup;
        }
    }
}
