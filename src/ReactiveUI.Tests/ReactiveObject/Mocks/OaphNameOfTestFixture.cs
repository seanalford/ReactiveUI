﻿// Copyright (c) 2019 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Reactive.Linq;
using System.Runtime.Serialization;

namespace ReactiveUI.Tests
{
    public class OaphNameOfTestFixture : TestFixture
    {
        [IgnoreDataMember]
        private readonly ObservableAsPropertyHelper<string> _firstThreeLettersOfOneWord;

        [IgnoreDataMember]
        private readonly ObservableAsPropertyHelper<string> _lastThreeLettersOfOneWord;

        public OaphNameOfTestFixture()
        {
            this.WhenAnyValue(x => x.IsOnlyOneWord).Select(x => x ?? string.Empty).Select(x => x.Length >= 3 ? x.Substring(0, 3) : x).ToProperty(this, nameof(FirstThreeLettersOfOneWord), out _firstThreeLettersOfOneWord);

            _lastThreeLettersOfOneWord = this.WhenAnyValue(x => x.IsOnlyOneWord).Select(x => x ?? string.Empty).Select(x => x.Length >= 3 ? x.Substring(x.Length - 3, 3) : x).ToProperty(this, nameof(LastThreeLettersOfOneWord));
        }

        [IgnoreDataMember]
        public string FirstThreeLettersOfOneWord => _firstThreeLettersOfOneWord.Value;

        [IgnoreDataMember]
        public string LastThreeLettersOfOneWord => _lastThreeLettersOfOneWord.Value;
    }
}
