using System.Collections.Generic;
using DynamicData.Binding;
using ReactiveUI;

namespace LiveSubgenerator.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private string _subtitleText = "Waiting for audio...";
        private string _selectedLanguage = "Auto Detect";

        // This list will fill your Dropdown
        public List<string> AvailableLanguages { get; } = new()
        {
            "Auto Detect", "Spanish", "French", "German", "Japanese", "Chinese"
        };

        public string SelectedLanguage
        {
            get => _selectedLanguage;
            set => this.SetProperty(ref _selectedLanguage, value);
        }

        public string SubtitleText
        {
            get => _subtitleText;
            set => this.SetProperty(ref _subtitleText, value);
        }
    }
}