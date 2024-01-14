import { CATEGORIES_URL } from "@/global/urls";
import { listProviderFactory } from "./factories/listsFactory";
import { useContext } from "react";

type Category = {
  id: string; 
  name: string;
}

const {context, ProviderElement: CategoriesListProvider} = listProviderFactory<Category>({
  baseUrl: CATEGORIES_URL
})

const useCategoriesList = () => {
  return useContext(context)
}

export{
  useCategoriesList,
  CategoriesListProvider
}

