import { CATEGORIES_URL } from "@/global/urls";
import { listProviderFactory } from "./factories/listsFactory";
import { useContext } from "react";
import Category from "@/models/category";

const { context, ProviderElement: CategoriesListProvider } = listProviderFactory<Category>({
  baseUrl: CATEGORIES_URL,
});

const useCategoriesList = () => useContext(context);

export { useCategoriesList, CategoriesListProvider };
