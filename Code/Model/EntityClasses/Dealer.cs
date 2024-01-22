﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.11.</auto-generated>
//------------------------------------------------------------------------------
#nullable enable
using System;
using System.Collections.Generic;

namespace llbltest.EntityClasses
{
	/// <summary>Class which represents the entity 'Dealer'.</summary>
	public partial class Dealer : CommonEntityBase
	{
		/// <summary>Method called from the constructor</summary>
		partial void OnCreated();
		private System.Int32 _id = default(System.Int32);

		/// <summary>Initializes a new instance of the <see cref="Dealer"/> class.</summary>
		public Dealer() : base()
		{
			this.Salesmen = new List<Salesman>();
			OnCreated();
		}

		/// <summary>Gets or sets the DealerName field. </summary>
		public System.String? DealerName { get; set; }
		/// <summary>Gets the Id field. </summary>
		public System.Int32 Id => _id;
		/// <summary>Gets or sets the OwnerId field. </summary>
		public Nullable<System.Int32> OwnerId { get; set; }
		/// <summary>Represents the navigator which is mapped onto the association 'Dealer.Owner - Owner.Dealers (1:1) (Model only)'</summary>
		public virtual Owner Owner { get; set; } = null!;
		/// <summary>Represents the navigator which is mapped onto the association 'Salesman.Dealer - Dealer.Salesmen (m:1)'</summary>
		public virtual List<Salesman> Salesmen { get; set; }
	}
}
