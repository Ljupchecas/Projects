const buttons = { 
    numOfColumns : document.getElementById('numberOfColumns'),
    cardBackgroundColor : document.getElementById('cardBackgroundColor'),
    cardSpaceBetween : document.getElementById('cardSpaceBetween'),
    lightTheme : document.getElementById('lightTheme'),
    darkTheme : document.getElementById('darkTheme'), 
    all : document.getElementById('all'),
    instagram : document.getElementById('instagram'),
    facebook : document.getElementById('facebook'),
    twitter : document.getElementById('twitter'),
    layoutPlaceholder : document.getElementsByClassName('layout-placeholder'),
	loadMore : document.getElementById('loadMore'),
	body : document.body,
}

let myArray = [];

const getData = () => {
	fetch("../data.json")
		.then((res) => res.json())
		.then((data) => {
			console.log(data);
			myArray = data;
			//myArray = filterData(data);
            showCards(0, 4);
			// myArray
			//   .filter((item, index) => index < 4)
			//   .forEach((element) => {
			// 	  createCard(element);
			// })
		});
};

const createCard = (post) => {
	let cardContainer = document.getElementsByClassName("layout-placeholder")[0];
	let card = document.createElement("div");
	card.classList.add("card");

	let cardHeader = document.createElement("div");
	cardHeader.classList.add("cardHeader");

	let profileImg = document.createElement("img");
	profileImg.classList.add("profileImage");
	profileImg.setAttribute("src", post.profile_image);
	cardHeader.appendChild(profileImg);

	let profileContent = document.createElement("div");
	profileContent.classList.add("profileContent");

	let profileName = document.createElement("h4");
	profileName.classList.add("profileName");
	profileName.textContent = post.name;
	profileContent.appendChild(profileName);

	let postDate = document.createElement("small");
	postDate.textContent = post.date;
	profileContent.appendChild(postDate);

	cardHeader.appendChild(profileContent);

	card.appendChild(cardHeader);

	let cardImage = document.createElement("img");
	cardImage.classList.add("cardImage");
	cardImage.setAttribute("src", post.image);
	card.appendChild(cardImage);

	let cardContent = document.createElement("div");
	cardContent.classList.add("cardContent");

	let contentCaption = document.createElement("div");
	if (post.caption.length > 100) {
		contentCaption.textContent = post.caption.substring(0, 100);
		contentCaption.textContent += "..";
		let showMoreSpan = document.createElement("span");
		showMoreSpan.classList.add("showMore");
		showMoreSpan.textContent = "Show More";
		contentCaption.appendChild(showMoreSpan);
	} else {
		contentCaption.textContent = post.caption;
	}
	cardContent.appendChild(contentCaption);

	let likesSpacer = document.createElement("hr");
	cardContent.appendChild(likesSpacer);

	let likes = document.createElement("p");
	likes.innerText = `${post.likes} likes`;
	cardContent.appendChild(likes);

	card.appendChild(cardContent);

	cardContainer.appendChild(card);

	buttons.cardBackgroundColor.addEventListener("change", () => {
		let card = document.getElementsByClassName("card");
		for (let i = 0; i < card.length; i++){
			card[i].style.backgroundColor = buttons.cardBackgroundColor.value;
		}
	});

	cardSpaceBetween.value = "10px";
	buttons.cardSpaceBetween.addEventListener("change", () => {
		let gapValue = `${cardSpaceBetween.value}px`;
		cardContainer.style.gap = gapValue;
	})
	

};

getData();

const showCards = (start, end) => {
    for (let i = start; i < end; i++) {
        createCard(myArray[i]);
    }
};

const loadMoreCards = () => {
    const numOfCardsToShow = 4;
    let currentCardsToShow = document.getElementsByClassName('card').length;

    if (currentCardsToShow >= myArray.length) {
        buttons.loadMore.style.display = "none";
        return;
    }

    while (buttons.layoutPlaceholder.firstChild) {
        buttons.layoutPlaceholder.removeChild(buttons.layoutPlaceholder.firstChild);
    }

    for (let i = currentCardsToShow; i < currentCardsToShow + numOfCardsToShow; i++) {
        if (i >= myArray.length) {
            break;
        }
        createCard(myArray[i]);
    }

    if (currentCardsToShow + numOfCardsToShow >= myArray.length) {
        buttons.loadMore.style.display = "none";
    }
};

buttons.loadMore.addEventListener("click", loadMoreCards);

function changeColumn()
{
  const cardContainer = document.getElementById("layout-placeholder");

  defaultNumColumns = setDynamic();
  
  let numColumns = defaultNumColumns;
  cardContainer.style.gridTemplateColumns = `repeat(${numColumns}, 1fr)`;

  const numColumnsDropdown = document.getElementById("numberOfColumns");
  numColumnsDropdown.addEventListener("change", () => {
    const selectedValue = numColumnsDropdown.value;
    if (selectedValue === "dynamic") {
      numColumns = setDynamic();
    } else {
      numColumns = parseInt(selectedValue);
    }
    cardContainer.style.gridTemplateColumns = `repeat(${numColumns}, 1fr)`;
  });
}

function setDynamic() 
{
    const screenWidth = window.innerWidth;
    
    if (screenWidth >= 992) {
      return 5;
    } else if (screenWidth >= 768) {
      return 4;
    } else {
      return 3;
    }
}

const filterBySource = (source) => {
	let filteredArray = myArray.filter((item) => item.source_type === source);
	showCards(0, 4);
  };
  
buttons.all.addEventListener("click", () => {
	showCards(0, 4);
});
  
buttons.instagram.addEventListener("click", () => {
	filterBySource("instagram");
});
  
buttons.facebook.addEventListener("click", () => {
	filterBySource("facebook");
});
  
buttons.twitter.addEventListener("click", () => {
	filterBySource("twitter");
});
  
buttons.darkTheme.addEventListener("click", () => { 
	buttons.body.style.backgroundColor = "black";
})

buttons.lightTheme.addEventListener("click", () => {
	buttons.body.style.backgroundColor = "white";
})