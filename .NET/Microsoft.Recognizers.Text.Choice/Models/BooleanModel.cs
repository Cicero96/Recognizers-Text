﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.Recognizers.Text.Choice.Parsers;

namespace Microsoft.Recognizers.Text.Choice.Models
{
    public class BooleanModel : ChoiceModel
    {
        public BooleanModel(IParser parser, IExtractor extractor) : base(parser,extractor)
        {

        }

        public override string ModelTypeName => Constants.MODEL_BOOLEAN;

        protected override SortedDictionary<string, object> GetResolution(ParseResult parseResult)
        {
            var data = parseResult.Data as OptionsParseDataResult;
            var results = new SortedDictionary<string, object>()
            {
                { "value", parseResult.Value },
                { "score", data.Score },
                { "otherResults", data.OtherMatches.Select(l => new
                    {
                        Text = l.Text,
                        Value = l.Value,
                        Score = l.Score
                    } 
                )},

            };
            

            return results;
        }
    }
}
