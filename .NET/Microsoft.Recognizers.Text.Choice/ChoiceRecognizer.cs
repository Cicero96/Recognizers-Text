﻿using System.Collections.Generic;
using Microsoft.Recognizers.Text.Choice.English.Extractors;
using Microsoft.Recognizers.Text.Choice.Extractors;
using Microsoft.Recognizers.Text.Choice.Models;
using Microsoft.Recognizers.Text.Choice.Parsers;

namespace Microsoft.Recognizers.Text.Choice
{
    public class ChoiceRecognizer : Recognizer<ChoiceOptions>
    {
        public ChoiceRecognizer(string targetCulture, ChoiceOptions options = ChoiceOptions.None, bool lazyInitialization = false)
            : base(targetCulture, options, lazyInitialization)
        {
        }

        public ChoiceRecognizer(string targetCulture, int options, bool lazyInitialization = false)
            : this(targetCulture, GetOptions(options), lazyInitialization)
        {
        }

        public ChoiceRecognizer(ChoiceOptions options = ChoiceOptions.None, bool lazyInitialization = true)
            : base(null, options, lazyInitialization)
        {
        }

        public ChoiceRecognizer(int options, bool lazyInitialization = true)
            : this(null, GetOptions(options), lazyInitialization)
        {
        }

        public IModel GetBooleanModel(string culture = null, bool fallbackToDefaultCulture = true)
        {
            return GetModel<BooleanModel>(culture, fallbackToDefaultCulture);
        }

        public static List<ModelResult> RecognizeBoolean(string query, string culture, ChoiceOptions options = ChoiceOptions.None, bool fallbackToDefaultCulture = true)
        {
            var recognizer = new ChoiceRecognizer(options);
            var model = recognizer.GetBooleanModel(culture, fallbackToDefaultCulture);
            return model.Parse(query);
        }

        protected override void InitializeConfiguration()
        {
            RegisterModel<BooleanModel>(
                Culture.English,
                (options) => new BooleanModel(new BooleanParser(), new BooleanExtractor(new EnglishBooleanExtractorConfiguration())));
        }
    }
}
