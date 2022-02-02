﻿using System;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AB RID: 1451
	public class FoodMenu : MonoBehaviour
	{
		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x06002490 RID: 9360 RVA: 0x001FAA40 File Offset: 0x001F8C40
		public static FoodMenu Instance
		{
			get
			{
				if (FoodMenu.instance == null)
				{
					FoodMenu.instance = UnityEngine.Object.FindObjectOfType<FoodMenu>();
				}
				return FoodMenu.instance;
			}
		}

		// Token: 0x06002491 RID: 9361 RVA: 0x001FAA60 File Offset: 0x001F8C60
		private void Awake()
		{
			this.SetMenuIcons();
			this.menuSelectorTarget = this.menuSlots[0].position.x;
			this.startY = this.menuSelector.position.y;
			this.startZ = this.menuSelector.position.z;
		}

		// Token: 0x06002492 RID: 9362 RVA: 0x001FAABC File Offset: 0x001F8CBC
		public void SetMenuIcons()
		{
			this.menuSlots = new List<Transform>();
			for (int i = 0; i < this.menuSlotParent.childCount; i++)
			{
				Transform child = this.menuSlotParent.GetChild(i);
				this.menuSlots.Add(child);
				if (this.foodItems.Count >= i)
				{
					child.GetChild(0).GetComponent<SpriteRenderer>().sprite = this.foodItems[i].largeSprite;
				}
			}
		}

		// Token: 0x06002493 RID: 9363 RVA: 0x001FAB33 File Offset: 0x001F8D33
		public void SetActive(int index)
		{
			this.menuSelectorTarget = this.menuSlots[index].position.x;
			this.interpolator = 0f;
			this.activeIndex = index;
		}

		// Token: 0x06002494 RID: 9364 RVA: 0x001FAB63 File Offset: 0x001F8D63
		public Food GetActiveFood()
		{
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[this.activeIndex]);
			food.name = this.foodItems[this.activeIndex].name;
			return food;
		}

		// Token: 0x06002495 RID: 9365 RVA: 0x001FAB98 File Offset: 0x001F8D98
		public Food GetRandomFood()
		{
			int index = UnityEngine.Random.Range(0, this.foodItems.Count);
			Food food = UnityEngine.Object.Instantiate<Food>(this.foodItems[index]);
			food.name = this.foodItems[index].name;
			return food;
		}

		// Token: 0x06002496 RID: 9366 RVA: 0x001FABE0 File Offset: 0x001F8DE0
		private void Update()
		{
			if (this.interpolator < 1f)
			{
				float x = Mathf.Lerp(this.menuSelector.position.x, this.menuSelectorTarget, this.interpolator);
				this.menuSelector.position = new Vector3(x, this.startY, this.startZ);
				this.interpolator += Time.deltaTime * this.selectorMoveSpeed;
			}
			else
			{
				this.menuSelector.transform.position = new Vector3(this.menuSelectorTarget, this.startY, this.startZ);
			}
			if (YandereController.rightButton)
			{
				this.IncrementSelection();
				return;
			}
			if (YandereController.leftButton)
			{
				this.DecrementSelection();
			}
		}

		// Token: 0x06002497 RID: 9367 RVA: 0x001FAC96 File Offset: 0x001F8E96
		private void IncrementSelection()
		{
			this.SetActive((this.activeIndex + 1) % this.menuSlots.Count);
			SFXController.PlaySound(SFXController.Sounds.MenuSelect);
		}

		// Token: 0x06002498 RID: 9368 RVA: 0x001FACB9 File Offset: 0x001F8EB9
		private void DecrementSelection()
		{
			if (this.activeIndex == 0)
			{
				this.SetActive(this.menuSlots.Count - 1);
			}
			else
			{
				this.SetActive(this.activeIndex - 1);
			}
			SFXController.PlaySound(SFXController.Sounds.MenuSelect);
		}

		// Token: 0x04004C55 RID: 19541
		private static FoodMenu instance;

		// Token: 0x04004C56 RID: 19542
		[Reorderable]
		public Foods foodItems;

		// Token: 0x04004C57 RID: 19543
		public Transform menuSelector;

		// Token: 0x04004C58 RID: 19544
		public Transform menuSlotParent;

		// Token: 0x04004C59 RID: 19545
		public float selectorMoveSpeed = 3f;

		// Token: 0x04004C5A RID: 19546
		private List<Transform> menuSlots;

		// Token: 0x04004C5B RID: 19547
		private float menuSelectorTarget;

		// Token: 0x04004C5C RID: 19548
		private float startY;

		// Token: 0x04004C5D RID: 19549
		private float startZ;

		// Token: 0x04004C5E RID: 19550
		private float interpolator;

		// Token: 0x04004C5F RID: 19551
		private int activeIndex;
	}
}
