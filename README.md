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


```json
{
	"copyright": [ { "language": "en-US", "text": "© CAPCOM" } ],
	"glossary": null,
	"quest-book": [ ],
	"behavior-decks": [ ]
```

Further structural data may be suggested by the community in due time.

#### Glossary

Current glossary terms:

+ `rule-box-concat` to display the *or* between alternatives on gathering phase cards

#### Quest Book

Each quest book may contain the following information:

+ `title` is the localizable name of the quest book
+ `short-title` is a localizable abbreviated name, e.g. to print on card corners
+ `version` allows for data versioning, e.g. to keep track of errata
+ `quests` contains a collection of quests as detailed below
+ `gathering-cards` contains a collection of gathering phase cards as detailed below

#### Quests

Each quest has a number of properties:

+ `target` is the localizable name of the goal of the quest, usually a monster name
+ `monster-id` is the canonical id of the target monster, e.g. `GreatJagras`. The intention is to allow tih cross-referencing information within the data file without i18n getting in the way
+ `quest-id` is the canonical id of the quest, e.g. `GreatJagras1` for the difficulty 1 quest hunting Great Jagras. Like `monster-id` the intention is to have non-localized names for references
+ `kind` is the localizable name for the quest type, such as Assigned or Investigation
+ `difficulty` is the numerical representation of the quest difficulty, i.e. `1` for a 1-star assigned quest
+ `time-limit` is the number of time cards available to the players
+ `scoutfly-level` is the required Scoutfly Level as a string to allow for ranges (e.g. `"3-7"`)
+ `starting` contains a collection of gathering phase cards, in sequential order, for successive attempts at the quest to start reading at
+ `layout` contains a data representation of the map layout for the quest

##### Layout

Maps are always 6x6 grids, with columns and rows counted from 1 to 6.

Each grid layout has the following components:

+ `monster` to describe the initial monster position, with the column (1 through 6) as `x`, the row (1 through 6) as `y` and the initial orientation as `facing` counting clock-wise in 45° intervals starting at North.
⋅⋅* So we get the mappings `1 = N, 2 = NE, 3 = E, 4 = SE, 5 = S, 6 = SW, 7 = W, 8 = NW`
+ `players` is a collection of player starting locations, each with `x` and `y` just like monster starting positions.
+ `terrain` is a collection of terrain nodes, each with a terrain type (known valid values being `bush|rock|pond`) on top of `x` and `y`

#### Gathering Phase Cards

Gathering phase cards contain the following components:

+ `number` is the number printed on the top of the card
+ `page` is the page number from the quest book for reference
+ `title` is a localizable name on the top, if applicable. Examples would be "Assigned Quest Starting Point"
+ `title-rule` is the localizable instructional part of the title, if applicable, e.g. getting a potion for starting at this card.
+ `flavor` is the localizable flavor text that tells the story.
+ `consequence` is the localizable reward and/or penalty that some cards have *in addition* to the rules to follow/select.
+ `rules` is a collection of rules to follow/select after reading the card.

##### Gathering Phase Card Rules

Gathering phase card rules have up to 3 elements:

+ `condition` is a localizable limitation on a rule's selectability, e.g. "The players may only select this option if they have X in their inventory."
+ `prompt` is the localizable call-to-action the players receive from this card, e.g. "Go forth with haste!"
+ `rules` are the localizable game mechanic actions, e.g. "Read card no. 17 next."

### CSV

As part of the published source code, there is a .NET7-based console application to parse JSON data and write CSV files.

The purpose is to utilize Adobe Photoshop variables logic to automatically fill prepared photoshop documents with the content specified.
As such, the CSV format may only make sense in the given context and can be understood to be merely an example.