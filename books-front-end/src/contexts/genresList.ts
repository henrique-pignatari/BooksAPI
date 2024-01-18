import { GENRE_URL } from "@/global/urls";
import { listProviderFactory } from "./factories/listsFactory";
import { useContext } from "react";
import Genre from "@/models/genre";

const { context, ProviderElement: GenresListProvider } = listProviderFactory<Genre>({
  baseUrl: GENRE_URL,
});

const useGenresList = () => useContext(context);

export { useGenresList, GenresListProvider };
