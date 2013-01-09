	
// =====================================================================================
// Copyright � 2005 by Shahed Khan. All rights are reserved.
// 
// If you like this code then feel free to go ahead and use it.
// The only thing I ask is that you don't remove or alter my copyright notice.
//
// Your use of this software is entirely at your own risk. I make no claims or
// warrantees about the reliability or fitness of this code for any particular purpose.
// If you make changes or additions to this code please mark your code as being yours.
// 
// website , email shahed.khan@gmail.com
// =====================================================================================


using System;
using System.Reflection;
using System.Web.Caching;
using System.Collections.Specialized;
using System.Configuration.Providers;
using SmartMassEmail.Entities;

namespace SmartMassEmail.Providers 
{
	public abstract class EmailDeQueueProvider : ProviderBase 
	{
		public static EmailDeQueueProvider Instance() 
		{
			// Use the cache because the reflection used later is expensive			
			Type type = null;
			string cacheKey = null;

			// Get the names of the providers
			EmailDeQueueConfiguration config = EmailDeQueueConfiguration.GetConfig();

			// Read the configuration specific information
			// for this provider
			Provider emailDeQueueProvider = (Provider) config.Providers[config.DefaultProvider];

			// In the cache?
			cacheKey = "EmailDeQueue::" + config.DefaultProvider;
			if (EntLibHelper.GetCachedObject(cacheKey) == null) {

				// The assembly should be in \bin or GAC, so we simply need
				// to get an instance of the type
				try {

					type = Type.GetType( emailDeQueueProvider.Type );

					// Insert the type into the cache					
					Type[] paramTypes = System.Type.EmptyTypes;
					EntLibHelper.StoreInCache( cacheKey, type.GetConstructor(paramTypes) );

				} catch (Exception e) {
					throw new Exception("Unable to load provider", e);
				}

			}

			// Load the configuration settings
			object[] paramArray = new object[0];
			return (EmailDeQueueProvider)(  ((ConstructorInfo)EntLibHelper.GetCachedObject(cacheKey)).Invoke(paramArray) );
		}

		public static EmailDeQueueProvider Instance(string providerName) 
		{
			// Use the cache because the reflection used later is expensive			
			Type type = null;
			string cacheKey = null;

			// Get the names of the providers
			EmailDeQueueConfiguration config = EmailDeQueueConfiguration.GetConfig();

			// Read the configuration specific information
			// for this provider
			Provider emailDeQueueProvider = (Provider) config.Providers[providerName];

			// In the cache?
			cacheKey = "EmailDeQueue::" + providerName;
			if (EntLibHelper.GetCachedObject(cacheKey) == null)
			{
				// The assembly should be in \bin or GAC, so we simply need
				// to get an instance of the type
				try 
				{

					type = Type.GetType( emailDeQueueProvider.Type );

					// Insert the type into the cache					
					Type[] paramTypes = System.Type.EmptyTypes;
					EntLibHelper.StoreInCache( cacheKey, type.GetConstructor(paramTypes) );

				} 
				catch (Exception e) 
				{
					throw new Exception("Unable to load provider", e);
				}
			}			
			// Load the configuration settings
			object[] paramArray = new object[0];
			return (EmailDeQueueProvider)(  ((ConstructorInfo)EntLibHelper.GetCachedObject(cacheKey)).Invoke(paramArray) );
		}


		public abstract TList<EmailMessage> Recieve();
        public abstract bool Delete(EmailMessage message);
	}
}
