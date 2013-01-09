
using System;
using System.Text;

using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;

using System.Runtime.Serialization;
using System.Xml.Serialization;


namespace SmartMassEmail.Entities
{
	/// <summary>
	/// Represents a strongly typed list of .netTiers table entity that can be accessed by index. 
	/// Provides methods to search, sort, and manipulate lists.
	/// </summary>
	[Serializable]
	public class TList<T> : ListBase<T> where T : IEntity, new()
   	{
		
		/// <summary>
		/// Initializes a new instance of the <see cref="T:TList{T}"/> class.
		/// </summary>
		public TList()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:TList{T}"/> class based on another list.
		/// </summary>
		public TList(IList existingList)
		{
		    if (existingList != null)
		    {
		        foreach (T item in existingList)
	            {
	                if (item != null)
		                this.Items.Add(item);
                }
            }
		}



	  #region RemoveEntity
	  /// <summary>
      /// Removes the entity item at the specified index and places it in the DeletedItems collection.
	  /// If this list were to be persisted, it would delete the entity from the repository.
      /// </summary>
      /// <param name="index">The zero-based index of the item to remove.</param>
      public void RemoveEntity(int index)
      {
			RemoveItem(index);
      }
	  #endregion 
	
      #region BindingList overrides

      /// <summary>
      /// Inserts the specified item in the list at the specified index.
      /// </summary>
      /// <param name="index">The zero-based index where the item is to be inserted.</param>
      /// <param name="item">The item to insert in the list.</param>
      protected override void InsertItem(int index, T item)
      {
         //Set the parentCollection property
         item.ParentCollection = this;

         base.InsertItem(index, item);
      }

      /// <summary>
      /// Removes the item at the specified index.
      /// </summary>
      /// <param name="index">The zero-based index of the item to remove.</param>
      protected override void RemoveItem(int index)
      {
         T item = Items[index];

         if (item != null)
         {
            //Move item to deleted collection(if not in added state)
            if (item.EntityState != EntityState.Added)
            {
			   item.MarkToDelete();
               DeletedItems.Add(item);
            }
            base.RemoveItem(index);
         }
      }

      #endregion

      #region ICloneable

      ///<summary>
      /// Creates an exact copy of this TList{T} instance.
      ///</summary>
      ///<returns>The TList{T} object this method creates, cast as an object.</returns>
      ///<implements><see cref="ICloneable.Clone"/></implements>
      public override object Clone()
      {
         return this.Copy();
      }

      ///<summary>
      /// Creates an exact copy of this TList{T} object.
      ///</summary>
      ///<returns>A new, identical copy of the TList{T}.</returns>
      public virtual TList<T> Copy()
      {
         TList<T> copy = new TList<T>();
         foreach (T item in this)
         {
            T itemCopy = (T)MakeCopyOf(item);
            copy.Add(itemCopy);
         }
         return copy;
      }
      #endregion ICloneable

      #region Added Functionality
      
      /// <summary>
			/// Accepts the changes made to underlyting entities.
			/// </summary>
      public virtual void AcceptChanges()
      {
      	for(int i = 0; i < this.Count; i++)
      	{
      		this[i].AcceptChanges();
      	}
      }

      /// <summary>
      /// Adds the data in this collection to another collection
      /// </summary>
      /// <param name="copyTo"></param>
      public virtual void CopyTo(TList<T> copyTo)
      {
	      // make sure not to duplicate the item if it's already there
	      ArrayList alreadySeenItem = new ArrayList();
	      foreach (T item in copyTo)
	      {
		      alreadySeenItem.Add(item.ToString());
	      }

	      foreach (T item in this)
	      {
		      T itemCopy = (T)MakeCopyOf(item);
		      if (alreadySeenItem.IndexOf(itemCopy.ToString()) < 0)
		      {
			      copyTo.Add(itemCopy);
		      }
	      }
      }

      /// <summary>
      ///		Indicates whether the collection was modified or not, and thus if it needs to be saved.
      /// </summary>
      ///<returns>true is the collection needs to be saved; otherwise false.</returns>
      public virtual bool IsDirty
      {
         get
         {
            return IsNewCount > 0 || IsDeletedCount > 0 || IsDirtyCount > 0;
         }
      }

      /// <summary>
      ///		Returns the number of items that have been marked new in the collection.
      /// </summary>
      ///<returns>the number of items that have been marked new in the collection</returns>
      public virtual int IsNewCount
      {
         get
         {
            int count = 0;
            foreach (T item in this)
            {
               //if(item.IsNew)
               if (item.EntityState == EntityState.Added)
                  count += 1;
            }
            return count;
         }
      }

      /// <summary>
      ///		Returns the number of items that have been marked to delete in the collection.
      /// </summary>
      ///<returns>the number of items that have been marked for deletation in the collection</returns>
      public virtual int IsDeletedCount
      {
         get
         {
            /*
            int count = 0;
            foreach(T item in this)
            {
                //if(item.IsDeleted)
                if(item.EntityState == EntityState.Deleted)
                    count += 1;
            }
            return count;
            */
            return DeletedItems.Count;
         }
      }

      /// <summary>
      ///		Returns the number of items that have been marked as modified in the collection.
      /// </summary>
      ///<returns>the number of items that have been marked as modified in the collection</returns>
      public virtual int IsDirtyCount
      {
         get
         {
            int count = 0;
            foreach (T item in this)
            {
               //if(item.IsDirty)
               if (item.EntityState == EntityState.Changed)
                  count += 1;
            }
            return count;
         }
      }
		
		/// <summary>
      /// Returns whether all items contained in the list.
      /// </summary>
      /// <value>True if all items are valid; otherwise False.</value>
      public virtual bool IsValid
      {
         get 
         {
            bool rtn = true;

            foreach (T item in this)
            {
               if (!item.IsValid)
               {
                  rtn = false;
                  break;
               }
            }

            return rtn;
         }
      }

      /// <summary>
      /// Returns a <see cref="List{T}"/> object of invalid items.
      /// </summary>
      public List<T> InvalidItems
      {
         get
         {
            List<T> invalidItems = new List<T>();

            foreach (T item in this)
            {
               if (!item.IsValid)
               {
                  invalidItems.Add(item);
               }
            }

            return invalidItems;
         }
      }

      #region Deleted items

      private List<T> deletedItems;

      /// <summary>
      /// Hold a collection of item that we want to delete. they are removed from the main collection, so the databinding is working.
      /// </summary>
      /// <remark>The save method will loop on this collection to delete item from the datasource.</remark>
      public List<T> DeletedItems
      {
         get
         {
            if (this.deletedItems == null)
            {
               this.deletedItems = new List<T>();
            }
            return this.deletedItems;
         }
      }

      #endregion

      /// <summary>
      /// Performs the specified action on each element of the specified array.
      /// </summary>
      /// <param name="list">The list.</param>
      /// <param name="action">The action.</param>
      public static void ForEach<U>(TList<U> list, Action<U> action) where U : IEntity, new()
      {
         list.ForEach(action);
      }
      
      /// <summary>
			/// Gets the range
			/// </summary>
			/// <param name="index">The index.</param>
			/// <param name="count">The count.</param>
			/// <returns></returns>
			public TList<T> GetRange(int index, int count)
			{
					if ((index < 0) || (count < 0))
					{
						throw new ArgumentOutOfRangeException((index < 0) ? "index" : "count", "ArgumentOutOfRange_NeedNonNegNum");
					}
					
					TList<T> list1 = new TList<T>();
					for (int i = index; i < index + count && i < this.Count; i++)
					{
						list1.Add(this.Items[i]);
					}
					return list1;
			}

      #endregion	Added Functionality

      #region Find
    
      ///<summary>
		/// Finds a collection of <see cref="IEntity" /> objects in the current list matching the search criteria.
		///</summary>
		/// <param name="column">Property of the object to search, given as a value of the 'Entity'Columns enum.</param>
		/// <param name="value">Value to find.</param>
		public virtual TList<T> FindAll(System.Enum column, object value)
		{
			return FindAll(column.ToString(), value, true);
		}

      ///<summary>
      /// Finds a collection of <see cref="IEntity" /> objects in the current list matching the search criteria.
      ///</summary>
      /// <param name="column">Property of the object to search, given as a value of the 'Entity'Columns enum.</param>
      /// <param name="value">Value to find.</param>
      /// <param name="ignoreCase">A Boolean indicating a case-sensitive or insensitive comparison (true indicates a case-insensitive comparison).  String properties only.</param>
      public virtual TList<T> FindAll(System.Enum column, object value, bool ignoreCase)
      {
         return FindAll(column.ToString(), value, ignoreCase);
      }

      ///<summary>
		/// Finds a collection of <see cref="IEntity" /> objects in the current list matching the search criteria.
		///</summary>
		/// <param name="propertyName">Property of the object to search.</param>
		/// <param name="value">Value to find.</param>
      public virtual TList<T> FindAll(string propertyName, object value)
      {
         return FindAll(propertyName, value, true);
      }

		///<summary>
		/// Finds a collection of <see cref="IEntity" /> objects in the current list matching the search criteria.
		///</summary>
		/// <param name="propertyName">Property of the object to search.</param>
		/// <param name="value">Value to find.</param>
      	/// <param name="ignoreCase">A Boolean indicating a case-sensitive or insensitive comparison (true indicates a case-insensitive comparison).  String properties only.</param>
		public virtual TList<T> FindAll(string propertyName, object value, bool ignoreCase)
		{
			PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
			PropertyDescriptor searchBy = props.Find(propertyName, true);
			
			TList<T> result = new TList<T>();
			
			int index = 0;
			
			while (index > -1)
			{
				index = this.FindCore(searchBy, value, index, ignoreCase);
				
				if (index > -1)
				{
					result.Add(this[index]);
				   
				   	//Increment the index to start at the next item
				   	index++;
				}
			}
			
			return result;		
		}
				
		/// <summary>
		/// Retrieves the all the elements that match the conditions defined by the specified predicate.
		/// </summary>
		/// <param name="match">The <see cref="T:System.Predicate`1"></see> delegate that defines the conditions of the elements to search for.</param>
		/// <returns>
		/// A <see cref="T:TList{T}"></see> containing all the elements that match the conditions defined by the specified predicate, if found; otherwise, an empty <see cref="T:TList{T}"></see>.
		/// </returns>
		/// <exception cref="T:System.ArgumentNullException">match is null.</exception>		
		public new TList<T> FindAll(Predicate<T> match) 
		{
			if (match == null)
		    {
		    	throw new ArgumentNullException("match");
		    }

			TList<T> result = new TList<T>();
			foreach (T item in this.Items)
			{
				if (match(item))
				{
					result.Add(item);
				}
			}
			return result;
		}
		
		/// <summary>
		/// Determines whether the <see cref="T:TList{T}"></see> contains elements that match the conditions defined by the specified predicate.
		/// </summary>
		/// <param name="match">The <see cref="T:System.Predicate`1"></see> delegate that defines the conditions of the elements to search for.</param>
		/// <returns>
		/// true if the <see cref="T:TList{T}"></see> contains one or more elements that match the conditions defined by the specified predicate; otherwise, false.
		/// </returns>
		/// <exception cref="T:System.ArgumentNullException">match is null.</exception>
		public bool Exists(Predicate<T> match)
		{
		      return (this.FindIndex(match) != -1);
		}
		
		/// <summary>
		/// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence within the entire <see cref="T:TList{T}"></see>.
		/// </summary>
		/// <param name="match">The <see cref="T:System.Predicate`1"></see> delegate that defines the conditions of the element to search for.</param>
		/// <returns>
		/// The zero-based index of the first occurrence of an element that matches the conditions defined by match, if found; otherwise, 1.
		/// </returns>
		/// <exception cref="T:System.ArgumentNullException">match is null.</exception>
		public int FindIndex(Predicate<T> match)
		{
		      return this.FindIndex(0, this.Count, match);
		}
		
		/// <summary>
		/// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence within the range of elements in the <see cref="T:TList{T}"></see> that extends from the specified index to the last element.
		/// </summary>
		/// <param name="startIndex">The zero-based starting index of the search.</param>
		/// <param name="match">The <see cref="T:System.Predicate`1"></see> delegate that defines the conditions of the element to search for.</param>
		/// <returns>
		/// The zero-based index of the first occurrence of an element that matches the conditions defined by match, if found; otherwise, 1.
		/// </returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">startIndex is outside the range of valid indexes for the <see cref="T:TList{T}"></see>.</exception>
		/// <exception cref="T:System.ArgumentNullException">match is null.</exception>
		public int FindIndex(int startIndex, Predicate<T> match)
		{
		      return this.FindIndex(startIndex, this.Count - startIndex, match);
		}
		
		/// <summary>
		/// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence within the range of elements in the <see cref="T:TList{T}"></see> that starts at the specified index and contains the specified number of elements.
		/// </summary>
		/// <param name="startIndex">The zero-based starting index of the search.</param>
		/// <param name="count">The number of elements in the section to search.</param>
		/// <param name="match">The <see cref="T:System.Predicate`1"></see> delegate that defines the conditions of the element to search for.</param>
		/// <returns>
		/// The zero-based index of the first occurrence of an element that matches the conditions defined by match, if found; otherwise, 1.
		/// </returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">startIndex is outside the range of valid indexes for the <see cref="T:TList{T}"></see>.-or-count is less than 0.-or-startIndex and count do not specify a valid section in the <see cref="T:TList{T}"></see>.</exception>
		/// <exception cref="T:System.ArgumentNullException">match is null.</exception>
		public int FindIndex(int startIndex, int count, Predicate<T> match)
		{
			if (startIndex > this.Count)
		    {
		    	throw new ArgumentOutOfRangeException("startIndex", "index is out of range");
		    }
		    
		    if ((count < 0) || (startIndex > (this.Count - count)))
		    {
		    	throw new ArgumentOutOfRangeException("count", "count is out of range");
		    }
		     
	      if (match == null)
	      {
	            throw new ArgumentNullException("match");
	      }
	      int num1 = startIndex + count;
	      for (int num2 = startIndex; num2 < num1; num2++)
	      {
	            if (match(this[num2]))
	            {
	                  return num2;
	            }
	      }
	      return -1;
		}


		#region Find All By

        ///<summary>
        /// Finds a collection of <see cref="IEntity" /> objects in the current list matching the search criteria.
        ///</summary>
        /// <param name="findAllByType"><see cref="FindAllByType" /> Type to easily search by</param>
        /// <param name="column">Property of the object to search, given as a value of the 'Entity'Columns enum.</param>
        /// <param name="value">Value to find.</param>
        public virtual TList<T> FindAllBy(FindAllByType findAllByType, System.Enum column, object value)
        {
            return FindAllBy(findAllByType, column.ToString(), value, true);
        }

        ///<summary>
        /// Finds a collection of <see cref="IEntity" /> objects in the current list matching the search criteria.
        ///</summary>
        /// <param name="findAllByType"><see cref="FindAllByType" /> Type to easily search by</param>
        /// <param name="column">Property of the object to search, given as a value of the 'Entity'Columns enum.</param>
        /// <param name="value">Value to find.</param>
        /// <param name="ignoreCase">A Boolean indicating a case-sensitive or insensitive comparison (true indicates a case-insensitive comparison).  String properties only.</param>
        public virtual TList<T> FindAllBy(FindAllByType findAllByType, System.Enum column, object value, bool ignoreCase)
        {
            return FindAllBy(findAllByType, column.ToString(), value, ignoreCase);
        }

        ///<summary>
        /// Finds a collection of <see cref="IEntity" /> objects in the current list matching the search criteria.
        ///</summary>
        /// <param name="findAllByType"><see cref="FindAllByType" /> Type to easily search by</param>
        /// <param name="propertyName">Property of the object to search.</param>
        /// <param name="value">Value to find.</param>
        public virtual TList<T> FindAllBy(FindAllByType findAllByType, string propertyName, object value)
        {
            return FindAllBy(findAllByType, propertyName, value, true);
        }

        ///<summary>
        /// Finds a collection of <see cref="IEntity" /> objects in the current list matching the search criteria.
        ///</summary>
        /// <param name="findAllByType"><see cref="FindAllByType" /> Type to easily search by</param>
        /// <param name="propertyName">Property of the object to search.</param>
        /// <param name="value">Value to find.</param>
        /// <param name="ignoreCase">A Boolean indicating a case-sensitive or insensitive comparison (true indicates a case-insensitive comparison).  String properties only.</param>
        public virtual TList<T> FindAllBy(FindAllByType findAllByType, string propertyName, object value, bool ignoreCase)
        {
            PropertyDescriptorCollection props = base.PropertyCollection;
            PropertyDescriptor searchBy = props.Find(propertyName, true);

            TList<T> result = new TList<T>();

            int index = 0;

            while (index > -1)
            {
                index = this.FindAllBy(findAllByType, searchBy, value, index, ignoreCase);

                if (index > -1)
                {
                    result.Add(this[index]);

                    //Increment the index to start at the next item
                    index++;
                }
            }

            return result;
        }
		
        /// <summary>
        /// Searches for the index of the item that has the specified property descriptor with the specified value.
        /// </summary>
        /// <param name="findAllByType"><see cref="FindAllByType" /> Type to easily search by</param>
        /// <param name="prop">The <see cref="PropertyDescriptor"> to search for.</see></param>
        /// <param name="key">The value of <i>property</i> to match.</param>
        /// <param name="start">The index in the list at which to start the search.</param>
        /// <param name="ignoreCase">Indicator of whether to perform a case-sensitive or case insensitive search (string properties only).</param>
        /// <returns>The zero-based index of the item that matches the property descriptor and contains the specified value. </returns>
        protected virtual int FindAllBy(FindAllByType findAllByType, PropertyDescriptor prop, object key, int start, bool ignoreCase)
        {
            // Simple iteration:
            for (int i = start; i < Count; i++)
            {

                T item = this[i];
                object temp = prop.GetValue(item);
                if ((key == null) && (temp == null))
                {
                    return i;
                }
                else if (temp is string)
                {
                    switch(findAllByType)
                    {
                        case FindAllByType.StartsWith:
                            {
                               if (temp.ToString().StartsWith(key.ToString(), ignoreCase == true ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture))
                                	return i;
                                break;
                            }
                        case FindAllByType.EndsWith:
                            {
                                if (temp.ToString().EndsWith(key.ToString(), ignoreCase == true ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture))
                                	return i;
                                break;
                            }
                        case FindAllByType.Contains:
                            {
                                if (temp.ToString().Contains(key.ToString()))
                                	return i;
                                break; 
                            }
                    }
                }
                else if (temp != null && temp.Equals(key))
                {
                    return i;
                }
            }
            return -1; // Not found
        }
	    
	    ///<summary>
	    /// Used to by FindAllBy method to all for easy searching.
	    /// </summary>
	    [Serializable]
	    public enum FindAllByType
	    {
	        /// <summary>
	        /// Starts with Value in List
	        /// </summary>
	        StartsWith,
	        
	        /// <summary>
	        /// Ends with Value in List
	        /// </summary>
	        EndsWith,
	        
	        /// <summary>
	        /// Contains Value in List
	        /// </summary>
	        Contains
	    }
        #endregion Find All By

      #endregion Find


   }
}
