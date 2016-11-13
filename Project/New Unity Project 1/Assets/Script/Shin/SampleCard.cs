using UnityEngine;
public class SampleCard : Card {
	public SampleCard() {
		id = 1;
		card_name = "Sample Card";
		description = "Hello World!";
		sprite = Resources.Load("Sprite\\samplecard", typeof(Sprite)) as Sprite;
		cost = 3;
		hp = 10;
		atk = 5;
	}
}
public class TempleCard : Card {
	public TempleCard() {
		id = 2;
		card_name = "Temple Card";
		description = "A Lame Pun";
		sprite = Resources.Load("Sprite\\templecard", typeof(Sprite)) as Sprite;
		cost = 4;
		hp = 7;
		atk = 3;
	}
}
public class GambleCard : Card {
	public GambleCard() {
		id = 3;
		card_name = "Gamble Card";
		description = "GOOD!";
		sprite = Resources.Load<Sprite>("Sprite\\gamblecard");
		cost = 5;
		hp = 6;
		atk = 6;
	}
}
public class PimpleCard : Card {
	public PimpleCard() {
		id = 4;
		card_name = "Pimple Card";
		description = "Explodable";
		sprite = Resources.Load<Sprite>("Sprite\\gamplecard");
		cost = 5;
		hp = 7;
		atk = 2;
	}
}
public class CreditCard : Card {
	public CreditCard() {
		id = 5;
		card_name = "Credit Card";
		description = "Buy Now: $9.99 Quick Pay via PayPal";
		sprite = Resources.Load<Sprite>("Sprite\\creditcard");
		cost = 6;
		hp = 5;
		atk = 2;
	}
}
public class TarotCard : Card {
	public TarotCard() {
		id = 6;
		card_name = "Tarot Card";
		description = "ZA WARUDO!";
		sprite = Resources.Load<Sprite>("Sprite\\tarotcard");
		cost = 7;
		hp = 5;
		atk = 10;
	}
}
public class YetAnotherChristmasCard : Card {
	public YetAnotherChristmasCard() {
		id = 7;
		card_name = "Yet Another Christmas Card";
		description = "Yet Another Lame Pun";
		sprite = Resources.Load<Sprite>("Sprite\\templecard");
		cost = 8;
		hp = 4;
		atk = 7;
	}
}
public class UnknownCard : Card {
	public UnknownCard() {
		id = 8;
		card_name = "???";
		description = "What???";
		sprite = Resources.Load<Sprite>("Sprite\\templecard");
		cost = 8;
		hp = 2;
		atk = 1;
	}
}
public class PressureCannonCard : Card {
	public PressureCannonCard() {
		id = 9;
		card_name = "Pressure Cannon";
		description = "Apkbak";
		sprite = Resources.Load<Sprite>("Sprite\\pressure");
		cost = 8;
		hp = 1;
		atk = 116;
	}
}
public class MasterChuckCard : Card {
	public MasterChuckCard() {
		id = 10;
		card_name = "Master Chuck";
		description = "He can use HADOKEN!";
		sprite = Resources.Load<Sprite>("Sprite\\masterchuck");
		cost = 9;
		hp = 1;
		atk = 7;
	}
}
public class GodOfChickenCard : Card {
	public GodOfChickenCard() {
		id = 11;
		card_name = "God of Chicken";
		description = "All Hail Chicken: We love God because he sacrifeced for us with love, so chickens do.";
		sprite = Resources.Load<Sprite>("Sprite\\godofchicken");
		cost = 9;
		hp = 1;
		atk = 2;
	}
}
public class LibraryFairyCard : Card {
	public LibraryFairyCard() {
		id = 12;
		card_name = "LibraryFairy";
		description = "No Comment...";
		sprite = Resources.Load<Sprite>("Sprite\\libraryfairy");
		cost = 9;
		hp = 1;
		atk = 2;
	}
}
public class TobuchiCard : Card {
	public TobuchiCard() {
		id = 13;
		card_name = "Tobuchi";
		description = "Armed with: Battle Turtle Suit, 3 Burst Carrot Rifle, Acorn Grenade";
		sprite = Resources.Load<Sprite>("Sprite\\tobuchi");
		cost = 9;
		hp = 1;
		atk = 2;
	}
}
public class SnailCard : Card {
	public SnailCard() {
		id = 14;
		card_name = "Snail Card";
		description = "ERROR: Loading Timed Out";
		sprite = Resources.Load<Sprite>("Sprite\\snailcard");
		cost = 9;
		hp = 1;
		atk = 2;
	}
}




