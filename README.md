# MHW-BG-DataTool

## Abstract

This tool is meant for homebrewing / creative work associated with Monster Hunter: World - The Board Game as published by [Steamforged Games Ltd.](https://steamforged.com) based on the video game published by [CAPCOM Co., LTD](https://www.capcom.com/).

The data tool describes a common descriptive syntax for structured storing of data usually represented in card shape, such as quest, gathering phase or behavior cards.

## Copyright, License and attribution

The tool itself and its source code are provided under the CC0-1.0 license.

Neither the original author nor other contributors to this repository are in a position to grant any license whatsoever concerning the copyrights, trademarks and intellectual property of Steamforged Games Ltd. and CAPCOM Co., LTD, respectively.

## Syntax

### JSON

The primary data structure utilized in this repository is based on the JSON format.

#### Localization

In order to allow the community to translate content into any given langauge, data files are to be stored in UTF-8 encoding.

Any human-readable string within the data format is encapsulated in an i18n container.
The language code suggested is canonical BCP-47 tags ( language and region subtag, script subtag if necessary ).

```json
[
	{
		"language": "en-US",
		"text": "Hello World"
	},
	{
		"language": "ja-JP",
		"text": "ハロー・ワールド"
	}
]
```

When a `localized string` is mentioned in the following documentation, it refers to such a construct.
Any given implementation is suggested to provide a sensible default value.

E.g., when no translation is offered for a given `localized string` under the requested language tag, the first defined text is used.
This provides translators with placeholder texts.

#### Root

The root node of each data file contains a number of (optional) children:

+ A localized string concerning the copyright notice to (possibly) be put on cards and such.
+ A glossary of commonly used words, for example the *or* written between different choices on a gathering phase card.
+ A list of monsters described in the data file
+ A list of quest books described in the data file, with quest details and gathering phase cards.
+ A list of behavior cards.

Further structural data may be suggested by the community in due time.

### CSV

As part of the published source code, there is a .NET7-based console application to parse JSON data and write CSV files.

The purpose is to utilize Adobe Photoshop variables logic to automatically fill prepared photoshop documents with the content specified.
As such, the CSV format may only make sense in the given context and can be understood to be merely an example.