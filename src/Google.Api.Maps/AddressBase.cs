﻿/*
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Linq;
using Google.Api.Maps.Service.Geocoding;

namespace Google.Api.Maps
{
	public abstract class AddressBase : HierarchicalLocation
	{
        public string Street
        {
            get
            {
                return Components.HavingType(AddressType.Route).DefaultIfEmpty(new AddressComponent()).FirstOrDefault().LongName;
            }
        }

        public StreetNumber Number
        {
            get
            {
                return Components.HavingType(AddressType.StreetNumber).DefaultIfEmpty(new AddressComponent()).FirstOrDefault().LongName;
            }
        }

        public string PostalCode
        {
            get
            {
                return Components.HavingType(AddressType.PostalCode).DefaultIfEmpty(new AddressComponent()).FirstOrDefault().LongName;
            }
        }

        public Location Country
        {
            get
            {
                return new Location
                {
                    Name = Components.HavingType(AddressType.Country).DefaultIfEmpty(new AddressComponent()).FirstOrDefault().LongName
                };
            }
        }
    }
}