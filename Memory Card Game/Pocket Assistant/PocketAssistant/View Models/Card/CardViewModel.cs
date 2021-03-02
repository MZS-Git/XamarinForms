using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PocketAssistant.Helper.Alert;
using PocketAssistant.Model;
using PocketAssistant.ViewModels.Base;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace PocketAssistant.ViewModels.Card
{
    public class CardViewModel : BaseViewModel
    {

        public CardViewModel(INavigationService navigationService) : base(navigationService)
        {

            ImageSelectedCommand = new DelegateCommand<CardModel>(ShowSelectedImage);
            ImagesCollection = new ObservableCollection<CardModel>();
            PopulateImages();
            GenerateRandomizedNoList();
            Device.StartTimer(TimeSpan.FromSeconds(300 / 60), RandomizedImages); //Called after 5 Seconds
        }

        public DelegateCommand<CardModel> ImageSelectedCommand { get; private set; }

        List<int> randomList;

        public CardModel PreviousSelectedObj { get; set; }

        public int MatchedScore { get; set; }
        public int CountSelected { get; set; } = 0;

        public string PreviousSelectedOId { get; set; }

        public bool StartTimer { get; set; } = true;
        private bool IntializedTimer { get; set; } = false;

        private bool _visibleOnTap = true;
        public bool VisibleOnTap
        {
            get
            {
                return _visibleOnTap;
            }
            set
            {
                SetProperty(ref _visibleOnTap, value);
            }

        }


        private int _movesCounter;
        public int MovesCounter
        {
            get
            {
                return _movesCounter;
            }
            set
            {
                SetProperty(ref _movesCounter, value);
            }

        }

        private double _couter = 0.0;
        public double Counter
        {
            get
            {
                return _couter;
            }
            set
            {
                SetProperty(ref _couter, value);
            }

        }



        private ObservableCollection<CardModel> _imagesCollection;

        public ObservableCollection<CardModel> ImagesCollection
        {
            get
            {
                return _imagesCollection;
            }
            set
            {
                SetProperty(ref _imagesCollection, value);
            }
        }

        private Dictionary<string, string> imagesNames = new Dictionary<string, string>()
        {
            { "0","circle.png"},{"1","triangle.png" },{"2","oval.png" },{"3","convert.png" }

        };

        private bool RandomizedImages()
        {
            for (int i = 0; i < randomList.Count; i++)
            {
                var key = randomList[i].ToString();
                ImagesCollection.ElementAt(i).Images = "empty.png";
                ImagesCollection.ElementAt(i).TabId = key;
                ImagesCollection.ElementAt(i).IsFlipped = false;
            }

            return false;
        }


        private void GenerateRandomizedNoList()
        {
            int randomValue;
            randomList = new List<int>();
            Random randomNo = new Random();

            do
            {
                randomValue = randomNo.Next(4);//Generates from 0-3
                var duplicateRandomCount = randomList.Count(x => x == randomValue);

                if (duplicateRandomCount < 2)
                {
                    randomList.Add(randomValue);
                }

            } while (randomList.Count != 8); //Iterate until it store 8 randoms from 0-3


        }

        private void ShowSelectedImage(CardModel obj)
        {
            CountSelected += 1;

            if (!IntializedTimer)
            {
                CountDown();
                IntializedTimer = true;
            }

            //CheckWin();

            if (CountSelected == 1)
            {
                PreviousSelectedOId = obj.TabId;
                PreviousSelectedObj = obj;
                var matchedObj = ImagesCollection.Where(cardModel => cardModel == PreviousSelectedObj).FirstOrDefault();
                matchedObj.Images = imagesNames[PreviousSelectedOId];
                MovesCounter++;
            }

            if (CountSelected == 2)
            {
                if (PreviousSelectedOId == obj.TabId)
                {



                    var preMatchedObj = ImagesCollection.Where(x => x == PreviousSelectedObj).FirstOrDefault();
                    var CurrMatchedObj = ImagesCollection.Where(x => x == obj).FirstOrDefault();

                    if (CurrMatchedObj.IsFlipped != true && preMatchedObj.IsFlipped != true)
                    {
                        preMatchedObj.Images = imagesNames[PreviousSelectedOId];
                        preMatchedObj.IsFlipped = true;
                        CurrMatchedObj.Images = imagesNames[obj.TabId];
                        CurrMatchedObj.IsFlipped = true;

                        MatchedScore++;
                        CountSelected = 0;
                    }
                    else
                    {
                        CountSelected = 0;
                        return;
                    }


                }
                else
                {
                    //Flip back if not matched
                    PreviousSelectedObj.Images = "empty.png";
                    CountSelected = 0;
                }
                MovesCounter++;
            }

            CheckWin();

        }


        private async void CheckWin()
        {
            if (MatchedScore == 4)
            {
                StartTimer = false;
                await AlertHelper.ShowAlert("Memory Game", "Congratz You Win the Game in " + MovesCounter + " Moves and " + Counter + " Seconds");
                return;

            }
        }


        //Intiate Timer on First click.
        private bool CountDown()
        {
            Device.StartTimer(TimeSpan.FromSeconds(60 / 60), StartTime);
            return true;

        }


        private bool StartTime()
        {
            Counter += 1.0;
            return StartTimer;
        }

        //Summary:Display Non-Shuffle Images.
        private void PopulateImages()
        {
            ShowImages(imagesNames);
            ShowImages(imagesNames);
        }

        //Summary Show Images
        private void ShowImages(Dictionary<string, string> imagesDic)
        {
            foreach (var item in imagesDic)
            {
                CardModel cardModel = new CardModel
                {
                    Images = item.Value,
                    TabId = item.Key,
                    IsFlipped = true

                };

                ImagesCollection.Add(cardModel);
            }

        }
    }
}
