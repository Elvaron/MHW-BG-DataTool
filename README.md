# MHW-BG-DataTool

## Abstract

This tool is meant for homebrewing / creative work associated with Monster Hunter: World - The Board Game as published by [Steamforged Games Ltd.](https://steamforged.com) based on the video game published by [CAPCOM Co., LTD](https://www.capcom.com/).

The data tool describes a common descriptive syntax for structured storing of data usually represented in card shape, such as quest, gathering phase or behavior cards.

## Copyright, License and attribution

The tool itself and its source code are provided under the CC0-1.0 license.

Neither the original author nor other contributors to this repository are in a position to grant any license whatsoever concerning the copyrights, trademarks and intellectual property of Steamforged Games Ltd. and CAPCOM Co., LTD, respectively.

## JSON

The primary data structure utilized in this repository is based on the JSON format.

### Localization

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

### Root

The root node of each data file contains a number of (optional) children:

+ A localized string concerning the copyright notice to (possibly) be put on cards and such.
+ A glossary of commonly used words, for example the *or* written between different choices on a gathering phase card.
+ A list of monsters described in the data file
+ A list of quest books described in the data file, with quest details and gathering phase cards.
+ A list of time card decks

```json
{
	"copyright": [ { "language": "en-US", "text": "© CAPCOM" } ],
	"glossary": null,
	"quest-book": [ ],
	"behavior-decks": [ ],
	"time-card-decks": { "common":[], "decks":[] }
```

Further structural data may be suggested by the community in due time.

### Glossary

Current glossary terms:

+ `rule-box-concat` to display the *or* between alternatives on gathering phase cards
+ `abbreviation-page` to display the *P.* to refer to a book page
+ `scoutfly-level` to localize the term *Scoutfly Level*, i.e. the ranges for the track behavior cards
+ `starting-points` to localize the term *Starting Points* referring to the sequential attempt-wise starting gathering phase cards for a quest
+ `time-limit` to localize the term *Time Limit*, i.e. the amount of time cards available for this quest
+ `time cards` to localize the term *time cards*, i.e. the counting term behind the printed number of time cards available as the time limit

### Quest Book

Each quest book may contain the following information:

+ `name` is the localizable name of the quest book
+ `short-name` is a localizable abbreviated name, e.g. to print on card corners
+ `version` allows for data versioning, e.g. to keep track of errata
+ `quests` contains a collection of quests as detailed below
+ `gathering-card-decks` contains gathering phase card decks
+ `zone` these quests takes place, e.g. `ancient-forest|wildspire-waste|elders-recess|rotten-vale|coral-highlands`

#### Quests

Each quest has a number of properties:

+ `monster-id` is the canonical id of the target monster, e.g. `great-jagras`. The intention is to allow the cross-referencing information within the data file without i18n getting in the way.
+ `quest-id` is the canonical id of the quest, e.g. `great-jagras-1` for the difficulty 1 quest hunting Great Jagras. Like `monster-id`, the intention is to have non-localized names for references.
+ `quest-category` is the localizable name for the quest type, such as Assigned or Investigation
+ `quest-name` is the localizable name of the goal of the quest, usually a monster name, but it could potentially be anything.
+ `difficulty` is the numerical representation of the quest difficulty, i.e. `1` for a 1-star assigned quest
+ `time-limit` is the number of time cards available to the players
+ `page` is the numbered page in the questbook this quest appears on
+ `physiology` contains the physiology card for the monster and difficulty
+ `scoutfly-level` is the Scoutfly Level for behavior deck construction, containing
    + `min` numeric value
    + `max` numeric value
+ `starting` contains a collection of gathering phase cards, in sequential order, for successive attempts at the quest to start reading at
+ `layout` contains a data representation of the map layout for the quest

##### Physiology

Each physiology card has the following properties:

+ `monster-type` is the localizable name for the monster type, printed in smaller font above the monster's name
+ `hitpoints` is the number of hit points the monster has
+ `resistance` contains the elemental and status resistances the hunters need to overcome. `1` for 1 star, `2` for 2 stars. Immunity is written as `-1`
    + `fire`, `water`, `thunder`, `ice` and `dragon` are the elemental resistance properties
    + `paralysis`, `poison`, `sleep`, `blastblight`, `stun` are the status resistance properties
+ `special` contains the special rules associated with a monster's physiology
    + `name` is the localizable name for its special ability
    + `rules` is the localizable set of rules for this special ability.
+ `parts` contains a collection of monster body parts
    + `part` specifies the specific body part it refers to as a value of `head|body|tail|legs|claws|wings|null`
    + `arc` specifies which targeting arcs are active, containing
        + `front` as `true|false`
        + `back` as `true|false`
        + `left` as `true|false`
        + `right` as `true|false`
    + `armor` is the armor value of that body part
    + `break` is the break value of that body part
    + `rules` is the localizable set of rules to follow when that body part is broken
+ `rewards` is a collection representing the rewards table, with each having
    + `number` being the roll number needed
    + `item-reward` being the localizable name of the item dropped
    + `break-reward` being the localizable description of what body part to break to get how many of this item, if any

##### Layout

Maps are always 6x6 grids, with columns and rows counted from 1 to 6.

Positions are always given with an `x` coordinate representing the column (1-6) and a `y` coordinate representing the row (also 1-6).

Each grid layout has the following components:

+ `monsters` is a collection of initial monster positions (to support multiple monsters), each with
    + `monster-id` is the canonical id of the target monster
    + `x` and `y` for the position
    + `facing` for the initial orientation, counting clock-wise in 45° intervals starting at North.
        + So we get the mappings `1 = N, 2 = NE, 3 = E, 4 = SE, 5 = S, 6 = SW, 7 = W, 8 = NW`
+ `players` is a collection of player starting locations, each with `x` and `y` ositions.
+ `terrain` is a collection of terrain nodes, each with a terrain type (known valid values being `bush|rock|pond`) on top of `x` and `y`

#### Gathering Phase Card Decks

Each card deck consists of:

+ `monster-id` is the canonical id of the target monster, e.g. `great-jagras`.
+ `gathering-cards` is a collection of gathering cards as detailed below.

##### Gathering Phase Cards

Gathering phase cards contain the following components:

+ `number` is the number printed on the top of the card
+ `page` is the page number from the quest book for reference
+ `title` is a localizable name on the top, if applicable. Examples would be "Assigned Quest Starting Point"
+ `title-rule` is the localizable instructional part of the title, if applicable, e.g. getting a potion for starting at this card.
+ `flavor` is the localizable flavor text that tells the story.
+ `consequences` is a collection of localizable rewards and/or penalties that some cards have *in addition* to the rules to follow/select.
+ `rules` is a collection of rules to follow/select after reading the card.
+ `track-deck-info` specifies whether this card should include the track deck info for the monster, i.e. which behavior card to put it based on Scoutfly Level. In other words, this marks the "final" cards in the gathering phase deck.

##### Gathering Phase Card Rules

Gathering phase card rules have up to 3 elements:

+ `condition` is a localizable limitation on a rule's selectability, e.g. "The players may only select this option if they have X in their inventory."
+ `prompt` is the localizable call-to-action the players receive from this card, e.g. "Go forth with haste!"
+ `rules` are the localizable game mechanic actions, e.g. "Read card no. 17 next."

### Behavior Decks

Each monster is represented by the following elements:

+ `monster-id` is the canonical id of the target monster, e.g. `great-jagras`. The intention is to allow the cross-referencing information within the data file without i18n getting in the way.
+ `base-deck` is a collection of behavior cards the monster always comes equipped with.
+ `rage-deck` is a collection of behavior cards the monster uses once enraged[^1]
+ `special` is a collection of conditionally added / activated behavior cards.
+ `track-deck` is a struct of behavior cards added to the monster based on the number of Scoutfly tracks.

[^1]: A feature of Monster Hunter: World - Iceborne.

#### Behavior Cards

Each behavior card is represented by the following information:

+ `name` is the localizable name of the behavior card
+ `index` is the card's index, e.g. `145/148`
+ `target` can be a value of `far|close` to indicate who the monster will target
+ `part` is the card's monster body part as a value of `head|body|tail|legs|claws|wings|null`
+ `special-type` is the card's special type referenced by other texts, e.g. `supernova|nergigante-dive`
+ `actions` is a collection of actions as defined below
+ `activation` contains the activation information for hunters after the monster acts:
    + `hunters` is the number of hunter turns before the monster's next turn
    + `cards` is the number of attack cards each hunter may play in a given turn
+ `wind-up-activation` contains the activation information (see above for data contents) before the monster acts (wind-up, Iceborne feature)

##### Actions

Each action contains:

+ `type` as a value out of `move|attack`
+ `movement` containing
    + `front` movement by 0 or more nodes
    + `back` movement by 0 or more nodes
    + `left` side movement by 0 or more nodes
    + `right` side movement by 0 or more nodes
+ `targeting` as a value out of `arc|node`
+ `arc` will be `null` for `node` targeting, but for `arc` targeting contains
    + `front` as `true|false`
    + `back` as `true|false`
    + `left` as `true|false`
    + `right` as `true|false`
+ `range` is the range in number of nodes for the attack
+ `dodge` is the dodge value, i.e. how difficult the attack is for the hunters to dodge.
+ `damage` is the amount of damage dealt by the attack
+ `element` is one of `physical|fire|water|ice|thunder|dragon`
+ `status-ailment` is one of `stun|poison|sleep|paralysis|blast|null`

#### Special Behavior Cards

These represent specific abilities of monsters, like Teostra's Supernova.

To provide all necessary information, the entries are tuples:

```json
{
	"condition": "If all 12 blackscale dust tokens are on the game board when Teostra begins its turn, resolve the Supernova behavior card instead of drawing a behavior card.",
	"behavior": { /* Normal behavior card structure */ }
}
```

#### Track Deck

The track deck works different than a mere collection of behavior cards.
Players always add a specific behavior card to the deck if their Scoutfly track count is below or equal the minimum of the given quest's range, another one for below the maximum of the quest's range, and the last one for being equal or exceeding the maximum.
Directly associating each with the given condition avoids a sequence issue.

```json
{
	"less-or-equal-minimum": { /* Normal behavior card structure */ },
	"above-minimum-below-maximum": { /* Normal behavior card structure */ },
	"equal-or-more-maximum": { /* Normal behavior card structure */ }
}
```

### Time Card Decks

Time card decks contain the blue and red time cards included with each core set and expansion.
In play, you would only use one blue deck due to duplicates.

The time card decks node contains a `common-rule-sets` array since a lot of cards share the same text on the top.
There's really only one element in this array at this point, but with Icebore that might be different (we will see and adapt):
```json
{
    "id":"world",
    "rules":[
        {
            "language":"en-US",
            "text":"Flip your hunter token face down."
        },
        {
            "language":"en-US",
            "text":"Discard 1 attack card from the rightmost slot of your stamina board."
        },
        {
            "language":"en-US",
            "text":"Discard any number of attack cards from your hand."
        },
        {
            "language":"en-US",
            "text":"Draw attack cards until there are 5 cards in your hand."
        }
    ]
}
```

The time card decks node also contains a `decks` array, with a separate deck for each box set, containing
+ `name` as the localizable name of the expansion (e.g. `Ancient Forest`)
+ `short-name` as the localizable abbreviated name of the expansion for card bottoms (e.g. `MHW:AF`)
+ `card-limit` is the number of cards in that expansion card bottoms (i.e. `632` to get `MHW:AF 222/632`)
+ `common` references the common rule set (see above) to use
+ `cards` is a collection of time cards

#### Time Cards

Each time card contains the following information:
+ `type` being a value of `blue|red` to indicate whether it is part of a starting time deck or added during the hunt
+ `name` is the localizable name of the card
+ `rules` is a collection of localizable rule texts.[^2] Multiple 
+ `instances` is a collection of card id numbers for this card. Since the same card may appear multiple times (mostly in blue decks thus far), this encodes both the number of copies and their individual card numbers.

[^2]: Technically, all localizable texts are collections, since the data structure being an array of tuples `<language,text>` is not uniquely keyed to the language. How multiple texts for the same language are interpreted is up to the program that uses this JSON structure. You might merge them into continuous text or use the plurality as metadata to decide between different layouts.

## CSV Export

As part of the published source code, there is a .NET7-based console application to parse JSON data and write CSV files.

The purpose is to utilize Adobe Photoshop variables logic to automatically fill prepared photoshop documents with the content specified.
As such, the CSV format may only make sense in the given context and can be understood to be merely an example.