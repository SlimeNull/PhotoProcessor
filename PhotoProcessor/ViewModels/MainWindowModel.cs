using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using PhotoProcessor.Editing;
using PhotoProcessor.Editing.Layers;
using PhotoProcessor.Editing.Tools;
using PhotoProcessor.Messages;
using PhotoProcessor.Services;

namespace PhotoProcessor.ViewModels
{
    public partial class MainWindowModel : ObservableObject
    {
        private readonly IMessenger _messenger;
        private readonly ProjectManager _projectManager;

        [ObservableProperty]
        private Project _editingProject = new Project(512, 512, SkiaSharp.SKColorType.Bgra8888);

        [ObservableProperty]
        private Tool? _selectedTool;

        [ObservableProperty]
        private Layer? _selectedLayer;

        [ObservableProperty]
        private bool _pointSampling;

        public MainWindowModel(
            IMessenger messenger,
            ProjectManager projectManager)
        {
            _messenger = messenger;
            _projectManager = projectManager;
        }




        [RelayCommand]
        public void AddLayer()
        {
            var layer = EditingProject.Layers.AddNewNormalLayer();
            layer.Name = "New Layer";

            SelectedLayer = layer;

            _messenger.Send(UpdateProjectViewMessage.Instance);
        }

        [RelayCommand]
        public void RemoveLayer(Layer layer)
        {
            var layerIndex = EditingProject.Layers.IndexOf(layer);

            if (layerIndex < 0)
            {
                return;
            }

            EditingProject.Layers.RemoveAt(layerIndex);
            var newSelectedLayerIndex = layerIndex - 1;
            if (newSelectedLayerIndex < 0)
            {
                newSelectedLayerIndex = 0;
            }

            if (newSelectedLayerIndex < EditingProject.Layers.Count)
            {
                SelectedLayer = EditingProject.Layers[newSelectedLayerIndex];
            }

            _messenger.Send(UpdateProjectViewMessage.Instance);
        }
    }
}
