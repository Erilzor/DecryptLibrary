﻿using Decrypt_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Decrypt_Library.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminPage : TabbedPage
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        Product product = new Product();
        Category category = new Category();
        Event createdEvent = new Event();
        Language language = new Language(); 

        /// <summary>
        /// Product Bools
        /// </summary>
        #region Product bools
        bool ProductMediaIdCorrect { get; set; }    
        bool ProductStatusCorrect { get; set; } 
        bool ProductIsbnCorrect { get; set; } 
        bool ProductTitleCorrect { get; set; } 
        bool ProductDescriptionCorrect { get; set; } 
        bool ProductPagesCorrect { get; set; } 
        bool ProductPlaytimeCorrect { get; set; } 
        bool ProductPublisherCorrect { get; set; } 
        bool ProductLanguageIdCorrect { get; set; } 
        bool ProductAuthorNameCorrect { get; set; } 
        bool ProductPublishDateCorrect { get; set; } 
        bool ProductCategoryIdCorrect { get; set; } 
        bool ProductShelfIdCorrect { get; set; } 
        bool ProductNarratorCorrect { get; set; } 
        bool ProductNewProductCorrect { get; set; } 
        bool ProductAudienceIdCorrect { get; set; } 
        bool ProductHiddenProductCorrect { get; set; }

        bool ProductCorrectProductInput = false;
        #endregion

        /// <summary>
        /// Category Bools
        /// </summary>
        #region Category bools
        bool CateogryCorrectCategoryName { get; set; }
        #endregion

        /// <summary>
        /// Event Bools
        /// </summary>
        #region Event bools
        bool EventEventNameCorrect { get; set; }
        bool EventEventTimeCorrect { get; set; }
        bool EventEventDescrptionCorrect { get; set; }

        bool EventEventInputsCorrect = false;

        #endregion

        /// <summary>
        /// Resets all bools
        /// </summary>
        #region Bool Reset

        private void BoolReset()
        {
            ProductMediaIdCorrect = false;
            ProductStatusCorrect = false;
            ProductIsbnCorrect = false;
            ProductTitleCorrect = false;
            ProductDescriptionCorrect = false;
            ProductPagesCorrect = false;
            ProductPlaytimeCorrect = false;
            ProductPublisherCorrect = false;

            ProductLanguageIdCorrect = false;
            ProductAuthorNameCorrect = false;
            ProductPublishDateCorrect = false;
            ProductCategoryIdCorrect = false;
            ProductShelfIdCorrect = false;
            ProductNarratorCorrect = false;
            ProductNewProductCorrect = false;
            ProductAudienceIdCorrect = false;
            ProductHiddenProductCorrect = false;
            ProductCorrectProductInput = false;

            EventEventNameCorrect = false;
            EventEventTimeCorrect = false;
            EventEventDescrptionCorrect = false;
            EventEventInputsCorrect = false;
        }

        #endregion

        /// <summary>
        /// Buttons for Products
        /// </summary>
        #region Buttons tab1 products
        private void ShowNoWindows()
        {
            createProductTab.IsVisible = false;
            removeProductTab.IsVisible = false;
        }

        private void ShowProductsButton_Pressed(object sender, EventArgs e)
        {
            ProductList.IsVisible = true;
            ShowNoWindows();
            ProductList.ItemsSource = EntityFrameworkCode.EntityframeworkProducts.ShowAllProducts();
        }

        private void Button_AddProductClicked(object sender, EventArgs e)
        {
            createProductTab.IsVisible = true;
        }

        private void ProductList_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void entryTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryTitle.Text = e.NewTextValue;
        }

        private void entryISBN_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryISBN.Text = e.NewTextValue;
        }

        private void entryPublisher_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryPublisher.Text = e.NewTextValue;   
        }

        private void entryLanguage_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryLanguage.Text = e.NewTextValue;
        }

        private void entryAuthor_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryAuthor.Text = e.NewTextValue;
        }

        private void entryDate_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryDate.Text = e.NewTextValue;    
        }

        private void entryCategoryId_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryCategoryId.Text = e.NewTextValue;
        }

        private void entryShelfId_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryShelfId.Text = e.NewTextValue;
        }

        private void entryNarrator_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryNarrator.Text = e.NewTextValue;
        }

        private void entryAudienceId_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryAudienceId.Text = e.NewTextValue;
        }

        private void entryMediaId_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryMediaId.Text = e.NewTextValue;
        }

        private void entryDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryDescription.Text = e.NewTextValue;
        }

        private void entryPages_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryPages.Text = e.NewTextValue;
        }

        private void entryPlaytime_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryPlaytime.Text = e.NewTextValue;
        }

        private void entryProductRemove_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryProductRemove.Text = e.NewTextValue;
        }

        private void RemoveProductButton_Pressed(object sender, EventArgs e)
        {
            createProductTab.IsVisible = false;

            if (!removeProductTab.IsVisible)
            {
                removeProductTab.IsVisible = true;
                return;
            }
            try
            {
                if (Readers.Readers.IntReaderConvertStringToInt(entryProductRemove.Text, out int productId))
                {
                    product.Id = productId;
                    EntityFrameworkCode.EntityframeworkProducts.RemoveProduct(product);
                    removeProductTab.IsVisible = false;
                    ProductList.ItemsSource = EntityFrameworkCode.EntityframeworkProducts.ShowAllProducts();
                    entryProductRemove.Text = "";
                }
            }
            catch (Exception exception)
            {
                DisplayAlert("Error", $"{exception.Message}", "ok");
            }
        }

        #endregion

        /// <summary>
        /// Completetion button of Products
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Complete product add

        private void CompleteProduct_Pressed(object sender, EventArgs e)
        {
            ProductList.IsVisible = false;
            if (!createProductTab.IsVisible)
            {
                createProductTab.IsVisible = true;
                return;
            }

            int pagesInput = 0;
            double playTime = 0;
            int languageId = 0;
            int shelfId = 0;
            int categoryId = 0;
            int audienceId = 0;
            int mediaId = 0;
            long isbn = 0;
            DateTime date = DateTime.Now;

            try
            {
                ProductTitleCorrect = Readers.Readers.StringReader(entryTitle.Text);
                ProductDescriptionCorrect = Readers.Readers.StringReader(entryDescription.Text);
                ProductAuthorNameCorrect = Readers.Readers.StringReader(entryAuthor.Text);
                ProductPublisherCorrect = Readers.Readers.StringReader(entryPublisher.Text);
                ProductNarratorCorrect = Readers.Readers.StringReader(entryNarrator.Text);

                ProductPagesCorrect = Readers.Readers.IntReaderSpecifyIntRange(entryPages.Text, 1, 2000, out pagesInput);
                ProductPlaytimeCorrect = Readers.Readers.DoubleReaderOutDouble(entryPlaytime.Text, out playTime);

                ProductLanguageIdCorrect = Readers.Readers.LegalIDRangeLanguage(entryLanguage.Text, out languageId);
                ProductShelfIdCorrect = Readers.Readers.LegalIDRangeShelfId(entryShelfId.Text, out shelfId);
                ProductCategoryIdCorrect = Readers.Readers.LegalIDRangeCategoryId(entryCategoryId.Text, out categoryId);
                ProductAudienceIdCorrect = Readers.Readers.LegalIDRangeAudienceId(entryAudienceId.Text, out audienceId);
                ProductMediaIdCorrect = Readers.Readers.LegalIDRangeMediaId(entryMediaId.Text, out mediaId);
                ProductIsbnCorrect = Readers.Readers.LongReaderOutLong(entryISBN.Text, out isbn);
                ProductPublishDateCorrect = Readers.Readers.ReadDateTime(entryDate.Text, out date);

                ProductStatusCorrect = inStock.IsToggled;
                ProductNewProductCorrect = newProduct.IsToggled;
                ProductHiddenProductCorrect = hiddenProduct.IsToggled;



                if (!ProductTitleCorrect)
                    entryTitle.BackgroundColor = Color.MediumVioletRed;
                else
                    entryTitle.BackgroundColor = Color.White;

                if (!ProductDescriptionCorrect)
                    entryDescription.BackgroundColor = Color.MediumVioletRed;
                else
                    entryDescription.BackgroundColor = Color.White;

                if (!ProductAuthorNameCorrect)
                    entryAuthor.BackgroundColor = Color.MediumVioletRed;
                else
                    entryAuthor.BackgroundColor = Color.White;

                if (!ProductPublisherCorrect)
                    entryPublisher.BackgroundColor = Color.MediumVioletRed;
                else
                    entryPublisher.BackgroundColor = Color.White;

                if (!ProductNarratorCorrect)
                    entryNarrator.BackgroundColor = Color.MediumVioletRed;
                else
                    entryNarrator.BackgroundColor = Color.White;

                if (!ProductPagesCorrect)
                    entryPages.BackgroundColor = Color.MediumVioletRed;
                else
                    entryPages.BackgroundColor = Color.White;

                if (!ProductPlaytimeCorrect)
                    entryPlaytime.BackgroundColor = Color.MediumVioletRed;
                else
                    entryPlaytime.BackgroundColor = Color.White;

                if (!ProductLanguageIdCorrect)
                    entryLanguage.BackgroundColor = Color.MediumVioletRed;
                else
                    entryLanguage.BackgroundColor = Color.White;

                if (!ProductShelfIdCorrect)
                    entryShelfId.BackgroundColor = Color.MediumVioletRed;
                else
                    entryShelfId.BackgroundColor = Color.White;

                if (!ProductCategoryIdCorrect)
                    entryCategoryId.BackgroundColor = Color.MediumVioletRed;
                else
                    entryCategoryId.BackgroundColor = Color.White;

                if (!ProductAudienceIdCorrect)
                    entryAudienceId.BackgroundColor = Color.MediumVioletRed;
                else
                    entryAudienceId.BackgroundColor = Color.White;

                if (!ProductMediaIdCorrect)
                    entryMediaId.BackgroundColor = Color.MediumVioletRed;
                else
                    entryMediaId.BackgroundColor = Color.White;

                if (!ProductIsbnCorrect)
                    entryISBN.BackgroundColor = Color.MediumVioletRed;
                else
                    entryISBN.BackgroundColor = Color.White;

                if (!ProductPublishDateCorrect)
                    entryISBN.BackgroundColor = Color.MediumVioletRed;
                else
                    entryISBN.BackgroundColor = Color.White;

                ProductCorrectProductInput = ProductMediaIdCorrect
                                      && ProductStatusCorrect
                                      && ProductIsbnCorrect
                                      && ProductTitleCorrect
                                      && ProductDescriptionCorrect
                                      && ProductPagesCorrect
                                      && ProductPlaytimeCorrect
                                      && ProductPublisherCorrect
                                      && ProductLanguageIdCorrect
                                      && ProductAuthorNameCorrect
                                      && ProductPublishDateCorrect
                                      && ProductCategoryIdCorrect
                                      && ProductShelfIdCorrect
                                      && ProductNarratorCorrect
                                      && ProductNewProductCorrect
                                      && ProductAudienceIdCorrect
                                      && ProductHiddenProductCorrect;

                if (ProductCorrectProductInput)
                {
                    product.Title = entryTitle.Text;
                    product.Description = entryDescription.Text;
                    product.AuthorName = entryAuthor.Text;
                    product.Publisher = entryPublisher.Text;
                    product.Narrator = entryNarrator.Text;

                    product.Pages = pagesInput;
                    product.LanguageId = languageId;
                    product.ShelfId = shelfId;
                    product.CategoryId = categoryId;
                    product.AudienceId = audienceId;
                    product.MediaId = mediaId;
                    product.Isbn = isbn;
                    product.Playtime = playTime;
                    product.PublishDate = date;
                    product.NewProduct = newProduct.IsToggled;
                    product.HiddenProduct = hiddenProduct.IsToggled;
                    product.Status = inStock.IsToggled;

                    EntityFrameworkCode.EntityframeworkProducts.CreateProduct(product);

                    ProductList.ItemsSource = EntityFrameworkCode.EntityframeworkProducts.ShowAllProducts();
                    createProductTab.IsVisible = false;
                    ProductList.IsVisible = true;
                    BoolReset();
                }
                else
                    DisplayActionSheet($"Wrong input", "could not be inserted", "OK");

            }
            catch (Exception errormessage)
            {
                DisplayActionSheet($"{errormessage.Message}", "Error", "OK");
            }
        }

        #endregion

        /// <summary>
        /// Buttons for Category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Buttons tab2 categories

        private void entryCategoryNametab2_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryCategoryNametab2.Text = e.NewTextValue;
        }

        private void entryCategoryIdRemovetab2_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryCategoryIdtab2.Text = e.NewTextValue;
        }
        private void ShowCategories_Pressed(object sender, EventArgs e)
        {
            removeCategoryTab.IsVisible = false;
            createCategoryBar.IsVisible = false;
            categoryTab.IsVisible= true;
            categoryList.IsVisible= true;
            categoryList.ItemsSource = EntityFrameworkCode.EntityframeworkCategories.ShowAllCategories();
        }

        private void AddCategoryButton_Pressed(object sender, EventArgs e)
        {
            removeCategoryTab.IsVisible = false;
            if (!createCategoryBar.IsVisible)
            {
                createCategoryBar.IsVisible = true;
                return;
            }

            try
            {
                if (Readers.Readers.StringReader(entryCategoryNametab2.Text))
                {
                    category.CategoriesName = entryCategoryNametab2.Text;
                    EntityFrameworkCode.EntityframeworkCategories.CreateCategory(category);
                    createCategoryBar.IsVisible = false;
                    categoryList.ItemsSource = EntityFrameworkCode.EntityframeworkCategories.ShowAllCategories();
                    entryCategoryNametab2.Text = "";
                    category = null;
                }
            }

            catch (Exception)
            {
                DisplayAlert("Error", "not allowed input", "ok");
            }
        }

        private void RemoveCategoryButton_Pressed(object sender, EventArgs e)
        {
            createCategoryBar.IsVisible = false;
            if (!removeCategoryTab.IsVisible)
            {
                removeCategoryTab.IsVisible = true;
                return;
            }
            try
            {
                if (Readers.Readers.IntReaderConvertStringToInt(entryCategoryIdtab2.Text, out int categoryId))
                {
                    foreach (var products in EntityFrameworkCode.EntityframeworkProducts.ShowAllProducts())
                    {
                        if (products.CategoryId == categoryId)
                        {
                            DisplayActionSheet("Error", "You're not allowed to remove a category with existing products", "OK");
                            return;
                        }
                    }
                    category.Id = categoryId;
                    EntityFrameworkCode.EntityframeworkCategories.RemoveCategory(category);
                    removeCategoryTab.IsVisible = false;
                    categoryList.ItemsSource = EntityFrameworkCode.EntityframeworkCategories.ShowAllCategories();
                    entryCategoryIdtab2.Text = "";
                    category = null;
                }
            }
            catch (Exception exception)
            {
                DisplayAlert("Error", $"{exception.Message}", "ok");
            }
        }

        #endregion

        /// <summary>
        /// Buttons for Events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Buttons tab3 events
        private void ShowAllEvents_Pressed(object sender, EventArgs e)
        {
            removeEventTab.IsVisible = false;
            createEventBar.IsVisible = false;
            eventList.ItemsSource = EntityFrameworkCode.EntityframeworkEvents.ShowAllEvents();
        }

        private void entryEventNametab2_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryEventNametab2.Text = e.NewTextValue;
        }

        private void entryEventDescriptiontab2_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryEventDescriptiontab2.Text = e.NewTextValue;
        }

        private void entryEventTimetab2_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryEventTimetab2.Text = e.NewTextValue;
        }
        #endregion

        /// <summary>
        /// Buttons for Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Event buttons
        private void AddEventButton_Pressed(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            removeEventTab.IsVisible = false;

            if (!createEventBar.IsVisible) 
            {
                createEventBar.IsVisible = true;
                return;
            }

            try
            {
                EventEventNameCorrect = Readers.Readers.StringReader(entryEventNametab2.Text);
                EventEventTimeCorrect = Readers.Readers.ReadDateTime(entryEventTimetab2.Text, out date);
                if (!string.IsNullOrEmpty(entryEventDescriptiontab2.Text))
                    EventEventDescrptionCorrect = true;
            }
            catch
            {
                DisplayAlert("Error wrong input", "one of tha values were wrong", "ok");
            }

            EventEventInputsCorrect = EventEventNameCorrect 
                                           && EventEventTimeCorrect 
                                           && EventEventDescrptionCorrect;

            if (EventEventInputsCorrect)
            {
                try
                {
                    createdEvent.EventName = entryEventNametab2.Text;
                    createdEvent.Description = entryEventDescriptiontab2.Text;
                    createdEvent.Time = date;
                    EntityFrameworkCode.EntityframeworkEvents.CreateEvent(createdEvent);
                    eventList.ItemsSource = EntityFrameworkCode.EntityframeworkEvents.ShowAllEvents();
                    createEventBar.IsVisible = false;
                    createdEvent = null;
                }
                catch (Exception)
                {
                    DisplayAlert("Error", "not valid inputs", "OK");
                }
            }
        }

        private void RemoveEventButton_Pressed(object sender, EventArgs e)
        {
            int convertedSelectedId = 0;
            createEventBar.IsVisible = false;
            if (!removeEventTab.IsVisible)
            {
                removeEventTab.IsVisible = true;
                return;
            }

            try
            {
                if(Readers.Readers.LegalIDRangeEvent(entryEventRemovetab2.Text, out convertedSelectedId));
                {
                    createdEvent.Id = convertedSelectedId;
                    EntityFrameworkCode.EntityframeworkEvents.RemoveEvent(createdEvent);
                    createdEvent = null;
                    eventList.ItemsSource = EntityFrameworkCode.EntityframeworkEvents.ShowAllEvents();
                    removeEventTab.IsVisible = false; 
                }
            }
            catch (Exception)
            {
                DisplayAlert("Error", "not a valid input", "OK");
            }
        }

        private void entryEventRemovetab2_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryEventRemovetab2.Text = e.NewTextValue;
        }



        #endregion

        #region Language Buttons

        private void AddLanguageButton_Pressed(object sender, EventArgs e)
        {
            try
            {
                if (!createLanguageBar.IsVisible)
                {
                    createLanguageBar.IsVisible = true;
                    removeLanguageBar.IsVisible = false;
                    return;
                }

                if (Readers.Readers.StringReader(entryLanguageCreatetab3.Text))
                {
                    language.Languages = entryLanguageCreatetab3.Text;
                    EntityFrameworkCode.EntityframeworkLanguages.CreateLanguage(language);
                    languageList.ItemsSource = EntityFrameworkCode.EntityframeworkLanguages.ShowAllLanguages();
                    createLanguageBar.IsVisible = false;
                }
            } catch (Exception exception)
            {
                DisplayAlert("Error", $"{exception.Message}", "OK");
            }
        }
        #endregion

        private void RemoveLanguageButton_Pressed(object sender, EventArgs e)
        {
            if (!removeLanguageBar.IsVisible)
            {
                removeLanguageBar.IsVisible = true;
                createLanguageBar.IsVisible = false;
                return;
            }

            try
            {
                if (Readers.Readers.IntReaderConvertStringToInt(entryLanguageRemovetab3.Text, out int languageId))
                {
                    foreach (var item in EntityFrameworkCode.EntityframeworkProducts.ShowAllProducts())
                    {
                        if (languageId == item.LanguageId)
                        {
                            DisplayAlert("Error", "Can't remove a language with products associated to it", "OK");
                        }
                    }
                    language.Id = languageId;
                    EntityFrameworkCode.EntityframeworkLanguages.RemoveLanguage(language);
                    languageList.ItemsSource = EntityFrameworkCode.EntityframeworkLanguages.ShowAllLanguages();
                    removeLanguageBar.IsVisible = false;
                }
            } catch(Exception exception)
            {
                DisplayAlert("Error", $"{exception.Message}", "OK");
            }
        }

        private void entryLanguageCreatetab3_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryLanguageCreatetab3.Text = e.NewTextValue;  
        }

        private void entryLanguageRemovetab3_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryLanguageRemovetab3.Text = e.NewTextValue;
        }

        private void ShowLanguagesButton_Pressed(object sender, EventArgs e)
        {
            languageList.ItemsSource = EntityFrameworkCode.EntityframeworkLanguages.ShowAllLanguages();
        }
    }
}