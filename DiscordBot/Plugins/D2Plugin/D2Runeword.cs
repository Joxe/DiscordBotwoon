using System.Text;

namespace DiscordBot.Plugins.D2Plugin {
	class Runeword {
		#region Constants
		public const string 
			EL    = "El",    ELD  = "Eld",  TIR = "Tir", NEF  = "Nef",  ETH = "Eth", ITH = "Ith", 
			TAL   = "Tal",   RAL  = "Ral",  ORT = "Ort", THUL = "Thul", AMN = "Amn", SOL = "Sol", 
			SHAEL = "Shael", DOL  = "Dol",  HEL = "Hel", IO   = "Io",   LUM = "Lum", KO  = "Ko",
			FAL   = "Fal",   LEM  = "Lem",  PUL = "Pul", UM   = "Um",   MAL = "Mal", IST = "Ist",
			GUL   = "Gul",   VEX  = "Vex",  OHM = "Ohm", LO   = "Lo",   SUR = "Sur", BER = "Ber",
			JAH   = "Jah",   CHAM = "Cham", ZOD = "Zod";

		public const string
			BODY_ARMOR      = "Body Armor",      AXES    = "Axes",    SCEPTERS      = "Scepters",      HAMMERS      = "Hammers",
			MISSILE_WEAPONS = "Missile Weapons", WEAPONS = "Weapons", CLAWS         = "Claws",         SWORDS       = "Swords",
			POLEARMS        = "Polearms",        HELMS   = "Helms",   MELEE_WEAPONS = "Melee Weapons", PALA_SHIELDS = "Paladin Shields",
			STAVES          = "Staves",          MACES   = "Maces",   SHIELDS       = "Shields",       CLUBS        = "Clubs",
			WAND            = "Wand";

		public static readonly Runeword[] RUNEWORDS = {
			//Original
			new Runeword("Ancient's Pledge", new string[] { SHIELDS }              , new string[] { RAL, ORT, TAL }               , false),
			new Runeword("Black"           , new string[] { CLUBS, HAMMERS, MACES }, new string[] { THUL, IO, NEF }               , false),
			new Runeword("Fury"            , new string[] { MELEE_WEAPONS }        , new string[] { JAH, GUL, ETH }               , false),
			new Runeword("Holy Thunder"    , new string[] { SCEPTERS }             , new string[] { ETH, RAL, ORT, TAL }          , false),
			new Runeword("Honor"           , new string[] { MELEE_WEAPONS }        , new string[] { AMN, EL, ITH, TIR, SOL }      , false),
			new Runeword("King's Grace"    , new string[] { SWORDS, SCEPTERS }     , new string[] { AMN, RAL, THUL }              , false),
			new Runeword("Leaf"            , new string[] { STAVES }               , new string[] { TIR, RAL }                    , false),
			new Runeword("Lionheart"       , new string[] { BODY_ARMOR }           , new string[] { HEL, LUM, FAL }               , false),
			new Runeword("Lore"            , new string[] { HELMS }                , new string[] { ORT, SOL }                    , false),
			new Runeword("Malice"          , new string[] { MELEE_WEAPONS }        , new string[] { ITH, EL, ETH }                , false),
			new Runeword("Melody"          , new string[] { MISSILE_WEAPONS }      , new string[] { SHAEL, KO, NEF }              , false),
			new Runeword("Memory"          , new string[] { STAVES }               , new string[] { LUM, IO, SOL, ETH }           , false),
			new Runeword("Nadir"           , new string[] { HELMS }                , new string[] { NEF, TIR }                    , false),
			new Runeword("Radiance"        , new string[] { HELMS }                , new string[] { NEF, SOL, ITH }               , false),
			new Runeword("Rhyme"           , new string[] { SHIELDS }              , new string[] { SHAEL, ETH }                  , false),
			new Runeword("Silence"         , new string[] { WEAPONS }              , new string[] { DOL, ELD, HEL, IST, TIR, VEX }, false),
			new Runeword("Smoke"           , new string[] { BODY_ARMOR }           , new string[] { NEF, LUM }                    , false),
			new Runeword("Stealth"         , new string[] { BODY_ARMOR }           , new string[] { TAL, ETH }                    , false),
			new Runeword("Steel"           , new string[] { SWORDS, AXES, MACES }  , new string[] { TIR, EL }                     , false),
			new Runeword("Strength"        , new string[] { MELEE_WEAPONS }        , new string[] { AMN, TIR }                    , false),
			new Runeword("Venom"           , new string[] { WEAPONS }              , new string[] { TAL, DOL, MAL }               , false),
			new Runeword("Wealth"          , new string[] { BODY_ARMOR }           , new string[] { LEM, KO, TIR }                , false),
			new Runeword("White"           , new string[] { WAND }                 , new string[] { DOL, IO }                     , false),
			new Runeword("Zephyr"          , new string[] { MISSILE_WEAPONS }      , new string[] { ORT, ETH }                    , false),
			//1.10 Non-ladder
			new Runeword("Beast"              , new string[] { AXES, SCEPTERS, HAMMERS }, new string[] { BER, TIR, UM, MAL, LUM }     , false),
			new Runeword("Bramble"            , new string[] { BODY_ARMOR }             , new string[] { RAL, OHM, SUR, ETH }         , false),
			new Runeword("Breath of the Dying", new string[] { WEAPONS }                , new string[] { VEX, HEL, EL, ELD, ZOD, ETH }, false),
			new Runeword("Call to Arms"       , new string[] { WEAPONS }                , new string[] { AMN, RAL, MAL, IST, OHM }    , false),
			new Runeword("Chains of Honor"    , new string[] { BODY_ARMOR }             , new string[] { DOL, UM, BER, IST }          , false),
			new Runeword("Chaos"              , new string[] { CLAWS }                  , new string[] { FAL, OHM, UM }               , false),
			new Runeword("Crescent Moon"      , new string[] { AXES, SWORDS, POLEARMS } , new string[] { SHAEL, UM, TIR }             , false),
			new Runeword("Delirium"           , new string[] { HELMS }                  , new string[] { LEM, IST, IO }               , false),
			new Runeword("Doom"               , new string[] { BODY_ARMOR }             , new string[] { HEL, OHM, UM, LO, CHAM }     , false),
			new Runeword("Duress"             , new string[] { BODY_ARMOR }             , new string[] { SHAEL, UM, THUL }            , false),
			new Runeword("Enigma"             , new string[] { BODY_ARMOR }             , new string[] { JAH, ITH, BER }              , false),
			new Runeword("Eternity"           , new string[] { MELEE_WEAPONS }          , new string[] { AMN, BER, IST, SOL, SUR }    , false),
			new Runeword("Exile"              , new string[] { PALA_SHIELDS }           , new string[] { VEX, OHM, IST, DOL }         , false),
			new Runeword("Famine"             , new string[] { AXES, HAMMERS }          , new string[] { FAL, OHM, ORT, JAH }         , false),
			new Runeword("Gloom"              , new string[] { BODY_ARMOR }             , new string[] { FAL, UM, PUL }               , false),
			new Runeword("Hand of Justice"    , new string[] { WEAPONS }                , new string[] { SUR, CHAM, AMN, LO }         , false),
			new Runeword("Heart of the Oak"   , new string[] { STAVES, MACES }          , new string[] { KO, VEX, PUL, THUL }         , false),
			new Runeword("Kingslayer"         , new string[] { SWORDS, AXES }           , new string[] { MAL, UM, GUL, FAL }          , false),
			new Runeword("Passion"            , new string[] { WEAPONS }                , new string[] { DOL, ORT, ELD, LEM }         , false),
			new Runeword("Prudence"           , new string[] { BODY_ARMOR }             , new string[] { MAL, TIR }                   , false),
			new Runeword("Sanctuary"          , new string[] { SHIELDS }                , new string[] { KO, KO, MAL }                , false),
			new Runeword("Splendor"           , new string[] { SHIELDS }                , new string[] { ETH, LUM }                   , false),
			new Runeword("Stone"              , new string[] { BODY_ARMOR }             , new string[] { SHAEL, UM, PUL, LUM }        , false),
			new Runeword("Wind"               , new string[] { MELEE_WEAPONS }          , new string[] { SUR, EL }                    , false),
			//1.10 Ladder
			new Runeword("Brand"          , new string[] { MISSILE_WEAPONS }          , new string[] { JAH, LO, MAL, GUL }           , true),
			new Runeword("Death"          , new string[] { SWORDS, AXES }             , new string[] { HEL, EL, VEX, ORT, GUL }      , true),
			new Runeword("Destruction"    , new string[] { POLEARMS, SWORDS }         , new string[] { VEX, LO, BER, JAH, KO }       , true),
			new Runeword("Dragon"         , new string[] { BODY_ARMOR, SHIELDS }      , new string[] { SUR, LO, SOL }                , true),
			new Runeword("Dream"          , new string[] { HELMS, SHIELDS }           , new string[] { IO, JAH, PUL }                , true),
			new Runeword("Edge"           , new string[] { MISSILE_WEAPONS }          , new string[] { TIR, TAL, AMN }               , true),
			new Runeword("Faith"          , new string[] { MISSILE_WEAPONS }          , new string[] { OHM, JAH, LEM, ELD }          , true),
			new Runeword("Fortitude"      , new string[] { WEAPONS }                  , new string[] { BODY_ARMOR }                  , true),
			new Runeword("Grief"          , new string[] { SWORDS, AXES }             , new string[] { ETH, TIR, LO, MAL, RAL }      , true),
			new Runeword("Harmony"        , new string[] { MISSILE_WEAPONS }          , new string[] { TIR, ITH, SOL, KO }           , true),
			new Runeword("Ice"            , new string[] { MISSILE_WEAPONS }          , new string[] { AMN, SHAEL, JAH, LO }         , true),
			new Runeword("Infinity"       , new string[] { POLEARMS }                 , new string[] { BER, MAL, BER, IST }          , true),
			new Runeword("Insight"        , new string[] { POLEARMS, STAVES }         , new string[] { RAL, TIR, TAL, SOL }          , true),
			new Runeword("Last Wish"      , new string[] { SWORDS, HAMMERS, AXES }    , new string[] { JAH, MAL, JAH, SUR, JAH, BER }, true),
			new Runeword("Lawbringer"     , new string[] { SWORDS, HAMMERS, SCEPTERS }, new string[] { AMN, LEM, KO }                , true),
			new Runeword("Oath"           , new string[] { SWORDS, AXES, MACES }      , new string[] { SHAEL, PUL, MAL, LUM }        , true),
			new Runeword("Obedience"      , new string[] { POLEARMS }                 , new string[] { HEL, KO, THUL, ETH, FAL }     , true),
			new Runeword("Phoenix"        , new string[] { WEAPONS, SHIELDS }         , new string[] { VEX, VEX, LO, JAH }           , true),
			new Runeword("Pride"          , new string[] { POLEARMS }                 , new string[] { CHAM, SUR, IO, LO }           , true),
			new Runeword("Rift"           , new string[] { POLEARMS, SCEPTERS }       , new string[] { HEL, KO, LEM, GUL }           , true),
			new Runeword("Spirit"         , new string[] { SWORDS, SHIELDS }          , new string[] { TAL, THUL, ORT, AMN }         , true),
			new Runeword("Voice of Reason", new string[] { SWORDS, MACES }            , new string[] { LEM, KO, EL, ELD }            , true),
			new Runeword("Wrath"          , new string[] { MISSILE_WEAPONS }          , new string[] { PUL, LUM, BER, MAL }          , true),
			//1.11 Runewords
			new Runeword("Bone"         , new string[] { BODY_ARMOR }, new string[] { SOL, UM, UM }     , true),
			new Runeword("Enlightenment", new string[] { BODY_ARMOR }, new string[] { PUL, RAL, SOL }   , true),
			new Runeword("Myth"         , new string[] { BODY_ARMOR }, new string[] { HEL, AMN, NEF }   , true),
			new Runeword("Peace"        , new string[] { BODY_ARMOR }, new string[] { SHAEL, THUL, AMN }, true),
			new Runeword("Principle"    , new string[] { BODY_ARMOR }, new string[] { RAL, GUL, ELD }   , true),
			new Runeword("Rain"         , new string[] { BODY_ARMOR }, new string[] { ORT, MAL, ITH }   , true),
			new Runeword("Treachery"    , new string[] { BODY_ARMOR }, new string[] { SHAEL, THUL, LEM }, true)
		};
		#endregion

		public string   Name     { get; private set; }
		public int      Sockets  { get; private set; }
		public string[] ItemType { get; private set; }
		public string[] Runes    { get; private set; }
		public bool     Ladder   { get; private set; }

		public Runeword(string a_name, string[] a_itemType, string[] a_runes, bool a_ladder) {
			Name     = a_name;
			Sockets  = a_runes.Length;
			ItemType = a_itemType;
			Runes    = a_runes;
		}

		public string GetRunesAsString() {
			StringBuilder returnString = new StringBuilder("[");

			for (int i = 0; i < Runes.Length; ++i) {
				returnString.Append(Runes[i]);
				if (i + 1 != Runes.Length) {
					returnString.Append(" + ");
				}
			}

			returnString.Append("]");
			return returnString.ToString();
		}

		public string ToSingleLineString() {
			StringBuilder runesString = new StringBuilder("[");
			StringBuilder itemsString = new StringBuilder();

			for (int i = 0; i < ItemType.Length; ++i) {
				itemsString.Append(ItemType[i]);

				if (i + 1 != ItemType.Length) {
					itemsString.Append("/");
				}
			}

			for (int i = 0; i < Runes.Length; ++i) {
				runesString.Append(Runes[i]);

				if (i + 1 != Runes.Length) {
					runesString.Append(" + ");
				}
			}
			runesString.Append("]");

			return string.Format("{0} - {1} Socket {2} {3}", Name, Runes.Length, itemsString.ToString(), runesString.ToString());
		}

		public override string ToString() {
			StringBuilder runesString = new StringBuilder("[");
			StringBuilder itemsString = new StringBuilder();

			for (int i = 0; i < ItemType.Length; ++i) {
				itemsString.Append(ItemType[i]);

				if (i + 1 != ItemType.Length) {
					itemsString.Append("/");
				}
			}

			for (int i = 0; i < Runes.Length; ++i) {
				runesString.Append(Runes[i]);

				if (i + 1 != Runes.Length) {
					runesString.Append(" + ");
				}
			}
			runesString.Append("]");

			return string.Format("{0}\n{1} Socket {2}\n{3}", Name, Runes.Length, itemsString.ToString(), runesString.ToString());
		}
	}
}
